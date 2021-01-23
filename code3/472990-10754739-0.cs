    public static class HtmlExtensions
    {
        public static MvcHtmlString KO_ObjectFor<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            var stack = htmlHelper.ViewContext.HttpContext.Items["__scripts__"] as Stack<string>;
            if (stack == null)
            {
                stack = new Stack<string>();
            }
            String str = "some javascript code";
            stack.Push(str);
            return new HtmlString("some code that the helper needs to generate and output to the view");
        }
        public static IHtmlString FunctionToConcatenateJavaScript(this HtmlHelper htmlHelper)
        {
            var stack = htmlHelper.ViewContext.HttpContext.Items["__scripts__"] as Stack<string>;
            if (stack == null)
            {
                return MvcHtmlString.Empty;
            }
            var scriptTag = new TagBuilder("script");
            scriptTag.Attributes["type"] = "text/javascript";
            var sb = new StringBuilder();
            foreach (var script in stack)
            {
                sb.AppendLine(script);
            }
            scriptTag.InnerHtml = sb.ToString();
            return new HtmlString(scriptTag.ToString());
        }
    }
