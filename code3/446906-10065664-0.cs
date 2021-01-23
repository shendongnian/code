    public static IHtmlString Image(this HtmlHelper htmlHelper, string url)
    {
         return Image(htmlHelper, url, null);
    }
    
    public static IHtmlString Image(this HtmlHelper htmlHelper, string url, object htmlAttributes)
    {
         TagBuilder imgTag = new TagBuilder("img");
         UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
    
         imgTag.MergeAttribute("src", urlHelper.Content(url));
         imgTag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
    
         return new HtmlString(imgTag.ToString(TagRenderMode.SelfClosing));
    }
