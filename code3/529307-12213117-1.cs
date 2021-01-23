    public class DummyController : ApiController
    {
        [HttpGet]
        public string SayHello(string name="")
        {
            var q = GetQueryParameters(Request.RequestUri.Query);
            return string.Format("Hello {0}", name);
        }
    }
