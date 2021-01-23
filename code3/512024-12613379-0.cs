    public class FederationcallbackController : ApiController
    {
        public HttpResponseMessage Post()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.Redirect);
            response.Headers.Add("Location", "http://127.0.0.1:3949/api/federationcallback/end?acsToken=" + ExtractBootstrapToken());
            return response;
        }
        protected virtual string ExtractBootstrapToken()
        {
            return HttpContext.Current.User.BootstrapToken();
        }
    }
