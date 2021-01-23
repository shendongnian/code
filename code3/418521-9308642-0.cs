    public static MvcHtmlString ScriptTag(this HtmlHelper htmlHelper, string contentPath,
        string scriptType)
    {
        var httpContext = htmlHelper.ViewContext.HttpContext;
        var scriptTag = String.Format("<script src=\"{0}\" type=\"{1}\"></script>",
            UrlHelper.GenerateContentUrl(contentPath, httpContext),
            scriptType);
        return new MvcHtmlString(scriptTag);
    }
