    public static string GetParameter(this RequestContext requestContext, string key)
    {
        if (key == null) throw new ArgumentNullException("key");
    
        var lowKey = key.ToLower();
    
        return requestContext.RouteData.Values.ContainsKey(lowKey) &&
               requestContext.RouteData.Values[lowKey] != null
                   ? requestContext.RouteData.Values[lowKey].ToString()
                   : requestContext.HttpContext.Request.Params[lowKey];
    }
