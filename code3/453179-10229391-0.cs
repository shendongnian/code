    public static class TabExtensions
    {
        private class TabControl: IDisposable
        {
            private readonly ViewContext _viewContext;
            public TabControl(ViewContext viewContext)
	        {
                _viewContext = viewContext;
            }
            public void Dispose()
            {
                _viewContext.Writer.Write("</div>");
            }
        }
        public static IDisposable Tab(this HtmlHelper htmlHelper, bool active, object htmlAttributes)
        {
            var div = new TagBuilder("div");
            div.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            div.AddCssClass("tab-pane");
            if (active)
            {
                div.AddCssClass("active");
            }
            htmlHelper.ViewContext.Writer.Write(div.ToString(TagRenderMode.StartTag));
            return new TabControl(htmlHelper.ViewContext);
        }
    }
