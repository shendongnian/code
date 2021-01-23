    routes.IgnoreRoute("{file}.txt", new { pathInfo = new RobotsIgnore() });
    
    public class RobotsIgnore : IRouteConstraint
    {
    	public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    	{
    		return values[parameterName].ToString().ToLowerInvariant() != "robots.txt";
    	}
    }
