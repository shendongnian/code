    if(HttpContext.Current.Request.RequestContext.RouteData != null)
    {
        var value = HttpContext.Current.Request.RequestContext.RouteData.Values["Language"];
        lang = value == null ? null : value.ToString();
    }
