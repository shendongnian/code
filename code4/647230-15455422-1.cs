    public class CustomRoute : RouteBase
    {
      private readonly RouteBase route;
      
      public CustomRoute(RouteBase route)
      {
        this.route = route;
      }
      public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
      {
        values = new RouteValueDictionary(values.Select(v =>
        {
          return v.Key.Equals("action") || v.Key.Equals("controller")
            ? new KeyValuePair<String, Object>(v.Key, (v.Value as String).ToLower())
            : v;
        }).ToDictionary(v => v.Key, v => v.Value));
        return route.GetVirtualPath(requestContext, values);
      }
      public override RouteData GetRouteData(HttpContextBase httpContext)
      {
        return route.GetRouteData(httpContext);
      }
    }
