    public static MvcHtmlString Image(this HtmlHelper _helper, string _url, string _altText, object _htmlAttributes)
    {
        TagBuilder builder = new TagBuilder("image");
        TagBuilder anchorabBuilder = new TagBuilder("a"); 
    
        var path = _url.Split('?');
    
        string pathExtra = "";
    
        if (path.Length > 1)
        {
            pathExtra += "?" + path[1];
        }
    
        builder.Attributes.Add("src", VirtualPathUtility.ToAbsolute(path[0]) + pathExtra);
        builder.Attributes.Add("alt", _altText);
        builder.MergeAttributes(new RouteValueDictionary(_htmlAttributes));
        anchorabBuilder.InnerHtml = builder.ToString(TagRenderMode.SelfClosing);
        return MvcHtmlString.Create(anchorabBuilder.ToString(TagRenderMode.Normal));
    }
