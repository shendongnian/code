    public static bool IsRouteValueDefined(string routeKey, string routeValue)
    {
        var mvcHanlder = (MvcHandler)HttpContext.Current.Handler;
        var routeValues = mvcHanlder.RequestContext.RouteData.Values;
        var containsRouteKey = routeValues.ContainsKey(routeKey);
        if (routeValue == null)
            return containsRouteKey;
        return containsRouteKey && routeValues[routeKey].ToString().ToUpper() == routeValue.ToUpper();
    }
