    public static MvcHtmlString List(this HtmlHelperhelper, object htmlAttributes)
    {
        var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);        
        if (attributes.ContainsKey("class"))
            attributes["class"] = "myclass " + attributes["class"];
        else
            attributes.Add("class", "myClass");
        var tag = new TagBuilder("div");
        tag.MergeAttributes(attributes, false);
        
        return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
    }
