    public static string GetLocalResource(this HtmlHelper htmlHelper, string virtualPath, string resourceKey)
    {
        var resource = htmlHelper.ViewContext.HttpContext.GetLocalResourceObject(virtualPath, resourceKey);
        return resource != null ? resource.ToString() : string.Empty;
    }
    public static string Resource(this HtmlHelper htmlHelper, string resourceKey)
    {
        var virtualPath = ((WebViewPage) htmlHelper.ViewDataContainer).VirtualPath;
        return GetLocalResource(htmlHelper, virtualPath, resourceKey);
    }
