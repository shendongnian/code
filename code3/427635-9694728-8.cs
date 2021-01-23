    public class MyHttpHandler : IHttpHandler
    {
        public string Role { get; set; }
        public object RouteValues { get; set; }
        public MyHttpHandler(string role, object routeValues)
        {
            Role = role;
            RouteValues = routeValues;
        }
        public void ProcessRequest(HttpContext httpContext)
        {
            if (httpContext.User.IsInRole(Role))
            {
                RouteValueDictionary routeValues = new RouteValueDictionary(RouteValues);
                // put logic here to create path similar to what you were doing
                // before but you will need to replace any keys in your route 
                // with the values from the dictionary created above.
                httpContext.RewritePath(path);
            }
            IHttpHandler handler = new MvcHttpHandler();
            handler.ProcessRequest(httpContext);
        }
    }
