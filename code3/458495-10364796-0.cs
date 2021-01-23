    public class SessionHttpControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            return new SessionHttpControllerHandler(requestContext.RouteData);
        }
    }
    
    public class SessionHttpControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionHttpControllerHandler(RouteData routeData) : base(routeData) { }
    }
