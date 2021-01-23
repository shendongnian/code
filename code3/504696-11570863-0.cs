    public class HyphenatedRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.RouteData.Values["controller"] = requestContext.RouteData.Values["controller"].ToString().Replace("-", "_");
            try
            {
                requestContext.RouteData.Values["action"] = requestContext.RouteData.Values["action"].ToString().Replace("-", "_");
            }
            catch { }
            return base.GetHttpHandler(requestContext);
        }
    }
