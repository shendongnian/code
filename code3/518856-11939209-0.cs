    public static MvcHtmlString UnencodedActionLink(
        this HtmlHelper htmlHelper,
        string linkText,
        string actionName
    )
    {
        var str = UrlHelper.GenerateUrl(null, actionName, null, null, null, null, new RouteValueDictionary(), htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
        var a = new TagBuilder("a")
        {
            InnerHtml = !string.IsNullOrEmpty(linkText) ? linkText : string.Empty
        };
        a.MergeAttribute("href", str);
        return MvcHtmlString.Create(a.ToString(TagRenderMode.Normal));
    }
