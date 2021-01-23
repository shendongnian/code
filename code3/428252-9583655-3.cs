    public static MvcHtmlString MapLink(this MvcSiteMapHtmlHelper htmlHelper, string nodeKey)
        {
            return MapLink(htmlHelper, nodeKey, null, null);
        }
        public static MvcHtmlString MapLink(this MvcSiteMapHtmlHelper htmlHelper, string nodeKey, string linkText)
        {
            return MapLink(htmlHelper, nodeKey, linkText, null);
        }
        public static MvcHtmlString MapLink(this MvcSiteMapHtmlHelper htmlHelper, string nodeKey, string linkText, object htmlAttributes)
        {
            MvcSiteMapNode myNode = GetNodeByKey(htmlHelper, nodeKey);
            //we build the a tag
            TagBuilder builder = new TagBuilder("a");
            // Add attributes
            builder.MergeAttribute("href", myNode.Url);
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
            }
            if (!string.IsNullOrWhiteSpace(linkText))
            {
                builder.InnerHtml = linkText;
            }
            else
            {
                builder.InnerHtml = myNode.Title;
            }
            string link = builder.ToString();
            return  MvcHtmlString.Create(link);
        }
