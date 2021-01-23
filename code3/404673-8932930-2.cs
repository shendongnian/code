    public static MvcHtmlString Script(this HtmlHelper helper, string href, string text, bool openInNewWindow = false)
        {
            var builder = new TagBuilder("a");
            builder.MergeAttribute("href", href);
            if(openInNewWindow)
            {
               builder.MergeAttributes("target", "_blank");
            }
            builder.SetInnerText(text);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
