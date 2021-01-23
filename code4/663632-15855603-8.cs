    public class PhpConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext, Route route, string parameterName,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            string path = values[parameterName] as string;
            return (path != null) && path.EndsWith(".php",
                StringComparison.OrdinalIgnoreCase);
        }
    }
