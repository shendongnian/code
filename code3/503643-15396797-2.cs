    using System.Net.Http;
    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var responseOk = Request.CreateResponse(HttpStatusCode.OK);
            responseOk.Content = new StringContent(System.DateTime.Now.ToString());
            response.Headers.CacheControl = new CacheControlHeaderValue();
            response.Headers.CacheControl.MaxAge = new TimeSpan(0, 10, 0);  // 10 min. or 600 sec.
            response.Headers.CacheControl.Public = true;
            return responseOk;
        }
    }
