    public class LowercaseRoute : Route
    {
        public LowercaseRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler) { }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            values = new RouteValueDictionary(values.Select(v =>
            {
                return v.Key.Equals("action") || v.Key.Equals("controller")
                  ? new KeyValuePair<String, Object>(v.Key, (v.Value as String).ToLower())
                  : v;
            }).ToDictionary(v => v.Key, v => v.Value));
            return base.GetVirtualPath(requestContext, values);
        }
    }
