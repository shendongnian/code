    public static class ExternalLinkHelper
    {
        public static MvcHtmlString ExternalLink(this HtmlHelper htmlHelper, string linkText, string externalUrl)
        {
            TagBuilder tagBuilder = new TagBuilder("a");
            tagBuilder.Attributes["href"] = externalUrl;
            tagBuilder.InnerHtml = linkText;
            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
