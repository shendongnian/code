        ...
        using RazHeaderAttribute.Attributes;
        [Route("api/{controller}")]
        public class RandomController : ApiController 
        {
            ...
            // GET api/random
            [HttpGet]
            public IEnumerable<string> Get([FromHeader("pages")] int page, [FromHeader] string rows)
            {
                // Print in the debug window to be sure our bound stuff are passed :)
                Debug.WriteLine($"Rows {rows}, Page {page}");
                ...
            }
        }
   
