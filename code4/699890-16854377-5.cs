    public class TestController : ApiController
    {
        public HttpResponseMessage Post([FromBody]CustomRequest request)
        {
            // process request
            ...
            var resp = Request.CreateResponse<CustomResponse>(
                HttpStatusCode.OK,
                new CustomResponse() { ... }
            );
            
            //create and set cookie in response
            var cookie = new CookieHeaderValue("customCookie", "cookieVal");
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";
            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }
    }
