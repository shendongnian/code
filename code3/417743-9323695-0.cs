    public static class JavaScriptHelper
    {
        private const string JAVASCRIPTKEY = "js";
        public static void RegisterScript(this HtmlHelper helper, string script)
        {
            var jScripts = helper.ViewContext.TempData[JAVASCRIPTKEY]
                as IList<string>; // TODO should probably be an IOrderedEnumerable
            
            if (jScripts == null)
            {
                jScripts = new List<string>();
            }
            if (!jScripts.Contains(script))
            {
                jScripts.Add(script);
            }
            helper.ViewContext.TempData[JAVASCRIPTKEY] = jScripts;
        }
        public static MvcHtmlString RenderRegisteredScripts(this HtmlHelper helper)
        {
            var jScripts = helper.ViewContext.TempData[JAVASCRIPTKEY]
                as IEnumerable<string>;
            var result = String.Empty;
            if (jScripts != null)
            {
                var root = UrlHelper.GenerateContentUrl("~/scripts/partials/",
                        helper.ViewContext.HttpContext);
                result = jScripts.Aggregate("", (acc, fileName) =>
                    String.Format("<script src=\"{0}{1}.js\" " +
                        "type=\"text/javascript\"></script>\r\n", root, fileName));
            }
            return MvcHtmlString.Create(result);
        }
    }
