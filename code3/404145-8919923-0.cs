    using System.Web;
    using System.Web.Routing;
    public class PreserveQueryStringRoute : Route
    {
        public PreserveQueryStringRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if(HttpContext.Current != null)
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["XXX"]))
                    values.Add("XXX", HttpContext.Current.Request.QueryString["XXX"]);
                
            }
            var path = base.GetVirtualPath(requestContext, values);
            return path;
        }
    }
