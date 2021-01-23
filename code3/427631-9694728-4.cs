    public class MyRouteHandler : IRouteHandler
    {
        public string Role { get; set; }
        public object RouteValues { get; set; }
        public MyRouteHandler(string role, object routeValues)
        {
            Role = role;
            RouteValues = routeValues;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MyHttpHandler(Role, RouteValues);
        }
    }
