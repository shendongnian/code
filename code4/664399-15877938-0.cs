    public static class HtmlExtensions
    {
        private class Div : IDisposable
        {
            private readonly ViewContext context;
            private bool disposed;
 
            public Div(ViewContext context)
            {
                this.context = context;
            }
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    this.disposed = true;
                    context.Writer.Write("</div>");
                }
            }
        }
        public static IDisposable MyDiv(this HtmlHelper html, string id)
        {
            var div = new TagBuilder("div");
            if (!string.IsNullOrEmpty(id))
            {
                div.GenerateId(id);
            }
            html.ViewContext.Writer.Write(div.ToString(TagRenderMode.StartTag));
            return new Div(html.ViewContext);            
        }
    }
