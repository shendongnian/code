    public class DateTimeRouteConstraint : IRouteConstraint
    {
        public bool Match(System.Web.HttpContextBase httpContext, Route route, 
            string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            DateTime dateTime;
            return DateTime.TryParse(values[parameterName] as string, out dateTime);
        }
    }
