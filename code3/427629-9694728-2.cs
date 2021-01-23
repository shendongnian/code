    public class MyHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext httpContext)
        {
            if (httpContext.User.IsInRole(Roles.Administrator))
            {
                string path = //put logic here to create your path just like you were doing before
                httpContext.RewritePath(path);
            }
            IHttpHandler handler = new MvcHttpHandler();
            handler.ProcessRequest(httpContext);
        }
    }
