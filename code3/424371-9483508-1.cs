    public class CustomRoute : Route
    {
        #region Properties
        public ReadOnlyCollection<string> ExcludedRouteValuesNames { get; private set; }
        #endregion
        #region Constructor
        public CustomRoute(string url, IRouteHandler routeHandler, string commaSeparatedRouteValueNames)
            : this(url, routeHandler, (commaSeparatedRouteValueNames ?? string.Empty).Split(','))
        {
        }
        public CustomRoute(string url, IRouteHandler routeHandler, params string[] excludeRouteValuesNames)
            : base(url, routeHandler)
        {
            ExcludedRouteValuesNames = new ReadOnlyCollection<string>(excludeRouteValuesNames.Select(val => val.Trim()).ToList());
        }
        #endregion
        #region Route overrides
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (requestContext == null)
                throw new ArgumentNullException("requestContext");
            // create new route data and include only non-excluded values
            var excludedRouteData = new RouteData(this, this.RouteHandler);
            // add route values
            requestContext.RouteData.Values
                .Where(pair => !this.ExcludedRouteValuesNames.Contains(pair.Key, StringComparer.OrdinalIgnoreCase))
                .ToList()
                .ForEach(pair => excludedRouteData.Values.Add(pair.Key, pair.Value));
            // add data tokens
            requestContext.RouteData.DataTokens
                .ToList()
                .ForEach(pair => excludedRouteData.DataTokens.Add(pair.Key, pair.Value));
            // intermediary request context
            var currentContext = new RequestContext(new HttpContextWrapper(HttpContext.Current), excludedRouteData);
            // create new URL route values and include only none-excluded values
            var excludedRouteValues = new RouteValueDictionary(
                values
                    .Where(v => !this.ExcludedRouteValuesNames.Contains(v.Key, StringComparer.OrdinalIgnoreCase))
                    .ToDictionary(pair => pair.Key, pair => pair.Value)
            );
            var result = base.GetVirtualPath(currentContext, excludedRouteValues);
            return result;
        }
        #endregion
    }
