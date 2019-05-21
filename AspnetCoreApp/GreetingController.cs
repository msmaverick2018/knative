using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspnet.core
{
    [Route("api/v1/greetings")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public GreetingController(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        MyAppOptions Options { get; }

        [HttpGet("hello-goodbye")]
        public IActionResult HelloGoodbye()
        {
            var options = (IOptionsMonitor<MyAppOptions>)this._serviceProvider.GetService(typeof(IOptionsMonitor<MyAppOptions>));
            var currentValue = options.CurrentValue;
            return Ok(new
            {
                Greeting = currentValue.Greeting,
                Farewell = currentValue.Farewell
            });
        }
    }
}
