    public class CustomRoute : Route
    {
        private String _separator;
        public CustomRoute(string url,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            RouteValueDictionary dataTokens,String separator,IRouteHandler hdl)
            : base(url, defaults, constraints, dataTokens, hdl)
        {
            _separator = separator;
        }
        protected override bool ProcessConstraint(HttpContextBase httpContext,
            object constraint, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if(((string)values["sublocationurl"]).Contains(_separator))
            {
                var wholeParams = String.Format("{0}-{1}-{2}", values["sublocationurl"],_separator, values["villaurl"]).Split(new[]{_separator},StringSplitOptions.None);
                values["sublocationurl"] = wholeParams[0].Trim('-');
                values["villaurl"] = String.Join(_separator, wholeParams.Skip(1)).Trim('-');
            }
            return base.ProcessConstraint(httpContext, constraint,
                parameterName, values, routeDirection);
        }
    }
