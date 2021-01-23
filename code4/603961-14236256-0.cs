    public static class BeginViewHelper
    {
        public static IDisposable BeginView(this HtmlHelper helper, string viewId)
        {
            helper.ViewContext.Writer.Write("<div>");
            
            return new MyView(helper);
        }
        class MyView : IDisposable
        {
            private HtmlHelper helper;
            public MyView(HtmlHelper helper)
            {
                this.helper = helper;
            }
            
            public void Dispose()
            {
                this.helper.ViewContext.Writer.Write("</div>");
            }
        }
    }
