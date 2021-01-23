    public class LegacyRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
          RouteData result = null;
    
          string url = httpContext.Request.RawUrl.Substring(1);
    
          result = new RouteData(this, new MvcRouteHandler());
          result.Values.Add("controller", "Page");
          result.Values.Add("action", "Render");
          result.Values.Add("url", url);
    
          return result;
        }
    
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
          return null;
        }
    }
