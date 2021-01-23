    //Route all traffic through this controller with the base URL being the domain 
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //GET api/values
        [HttpGet("{a1?}/{a2?}/{a3?}/{a4?}/{a5?}")]
        public ActionResult<IEnumerable<string>> Get(string a1 = "", string a2 = "", string a3 = "", string a4 = "", string a5 = "")
        {
            //Custom logic processing each of the route values
            return new string[] { a1, a2, a3, a4, a5 };
        }
    }
