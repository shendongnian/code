public override string GetVaryByCustomString(HttpContext context, string custom)
{
    if (custom == "lisingtype")
    {
        return GetParamFromRouteData("listingtype", context);
    }
    if (custom == "propertytype")
    {
        return GetParamFromRouteData("propertytype", context);
    }
    if (custom == "location")
    {
        return GetParamFromRouteData("location", context);
    }
    return base.GetVaryByCustomString(context, custom);
}
private string GetParamFromRouteData(string routeDataKey, HttpContext context)
{
    object value;
    if (!context.Request.RequestContext.RouteData.Values.TryGetValue(routeDataKey, out value))
    {
        return null;
    }
    return value.ToString();
}
