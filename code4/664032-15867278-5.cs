    public static string GetGlobalResource(this HtmlHelper htmlHelper, string classKey, string resourceKey)
    {
        var resource = htmlHelper.ViewContext.HttpContext.GetGlobalResourceObject(classKey, resourceKey);
        return resource != null ? resource.ToString() : string.Empty;
    }
