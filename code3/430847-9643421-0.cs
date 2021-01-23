    public static class MyExtensionMethods
    {
        static MyExtensionMethods()
        {
            Renderer = (html, model) =>
            {
                // this is the default implementation that will be used by MVC runtime
                var viewDataContainer = new ViewDataContainer<INode>(model);
                var modelHtmlHelper = new HtmlHelper<INode>(html.ViewContext, viewDataContainer);
    
                return modelHtmlHelper.DisplayFor(node => node, "TemplateName");
            };
        }
        public static Func<HtmlHelper, INode, MvcHtmlString> Renderer { get; set; }
        public static MvcHtmlString Menu(this HtmlHelper html)
        {
            var model = new Model();
            return Renderer(html, model);
        }
    }
