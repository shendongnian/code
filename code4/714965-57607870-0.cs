    public abstract class RequestBase
    {
        public int ID { get; set; }
    }
    public class MyRequest : RequestBase
    {
        public string Name { get; set; }
    }
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        [HttpPost]
        [Route("GetName")]
        public IHttpActionResult GetName([FromBody]MyRequest _request)
        {
            return Ok("Test");
        }
    }
