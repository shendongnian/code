    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class MyFirstApiController : ApiController
    {
        // GET 
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Some   message here");
        }
    }
