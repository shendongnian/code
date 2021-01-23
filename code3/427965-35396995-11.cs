    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Mvc;
    
    namespace MyNamespace.Controllers
    {
        [Route("api/[controller]")]
        public class ItemsController : Controller
        {
            // GET: api/items
            [HttpGet()]
            public IEnumerable<string> Get()
            {
                return GetLatestItems();
            }
    
            // GET: api/items/5
            [HttpGet("{num}")]
            public IEnumerable<string> Get(int num)
            {
                return GetLatestItems(5);
            }       
    
            // GET: api/items/GetLatestItems
            [HttpGet("GetLatestItems")]
            public IEnumerable<string> GetLatestItems()
            {
                return GetLatestItems(5);
            }
    
            // GET api/items/GetLatestItems/5
            [HttpGet("GetLatestItems/{num}")]
            public IEnumerable<string> GetLatestItems(int num)
            {
                return new string[] { "test", "test2" };
            }
    
            // POST: /api/items/PostSomething
            [HttpPost("PostSomething")]
            public IActionResult Post([FromBody]string someData)
            {
                return Content("OK, got it!");
            }
        }
    }
