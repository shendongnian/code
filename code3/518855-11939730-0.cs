    public class CssManagerHttpHandlerRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            CssManager handler = new CssManager();
            HttpContext.Current.Items["s"] = requestContext.RouteData.Values["s"];
            return handler;
        }
    }
