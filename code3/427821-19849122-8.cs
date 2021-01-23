    public class TestController : ApiController
    {
        [HttpPost]
        [ActionName("TestRemoteIp")]
        public string TestRemoteIp()
        {
            return Request.GetClientIpAddress();
        }
    }
