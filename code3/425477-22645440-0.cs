    [RoutePrefix("api/example")]
    public class ExampleController : ApiController
    {
        [HttpGet]
        [Route("get1/{param1}")] //   /api/example/get1/1?param2=4
        public IHttpActionResult Get(int param1, int param2)
        {
            Object example = null;
            return Ok(example);
        }
    
    }
