    public static class HtmlExtensions
    {
        public static Func<object, dynamic> ScriptTag(this HtmlHelper htmlHelper, string url, string type)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var script = new TagBuilder("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = urlHelper.Content("~/" + url);
            return x => new HtmlString(script.ToString(TagRenderMode.Normal));
        }
        public static IHtmlString Resource(this HtmlHelper htmlHelper, Func<object, dynamic> renderer)
        {
            return renderer(null);
        }
    }
