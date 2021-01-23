    public class TestController : ApiController
    {
        public string Post([FromBody]string value)
        {
            return value;
        }
    }
