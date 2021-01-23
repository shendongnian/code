    public static class HtmlExtensions
    {
        public static HelperResult ScriptTag(this HtmlHelper htmlHelper, string url, string type)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var script = new TagBuilder("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = urlHelper.Content("~/" + url);
            return new HelperResult(writer =>
            {
                writer.Write(script.ToString(TagRenderMode.Normal));
            });
        }
        public static IHtmlString Resource(this HtmlHelper htmlHelper, HelperResult renderer)
        {
            return renderer;
        }
    }
