        public class SomeController : ApiController
        {
            [HttpGet()]
            [Route("GetItems")]
            public SomeValue GetItems(CustomParam parameter) { ... }
        
            [HttpGet()]
            [Route("GetChildItems")]
            public SomeValue GetChildItems(CustomParam parameter, SomeObject parent) { ... }
        }
