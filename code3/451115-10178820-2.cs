    public class MyCustomConstraint : IRouteConstraint{
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection){
            return routeDirection == RouteDirection.IncomingRequest;
        }
    }
