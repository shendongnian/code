    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if(routeDirection == RouteDirection.UrlGeneration)
            return false;
    
        ...
    }
