    public static MvcHtmlString ActionImage(this HtmlHelper html, 
        string controller, string action, object routeValues, 
        string imageSrc, string alternateText, object imageAttributes)
    {
        UrlHelper url = new UrlHelper(html.ViewContext.RequestContext);
    
        // build the <img> tag
        string img = Sprite.Image(imageSrc).ToHtmlString();
    
        // build the <a> tag
        TagBuilder anchorBuilder = new TagBuilder("a");
        anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
        anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
        string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
    
        return MvcHtmlString.Create(anchorHtml);
    }
