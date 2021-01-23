    @using (Html.Td(item, isBlocked))
    {
        <div>some contents for the td</div>
    }
    
    like this:
    
    public static class HtmlExtensions
    {
        private class TdElement : IDisposable
        {
            private readonly ViewContext _viewContext;
            private bool _disposed;
    
            public TdElement(ViewContext viewContext)
            {
                if (viewContext == null)
                {
                    throw new ArgumentNullException("viewContext");
                }
                _viewContext = viewContext;
            }
    
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (!this._disposed)
                {
                    _disposed = true;
                    _viewContext.Writer.Write("</td>");
                }
            }
        }
    
        public static IDisposable Td(this HtmlHelper html, ItemViewModel item, bool isBlocked)
        {
            var td = new TagBuilder("td");
            var title = item.Cancelled 
                ? "Cancelled" 
                : item.Confirmed 
                    ? isBlocked 
                        ? "blocked date" 
                        : "" 
                    : "Confirm needed";
    
            if (!string.IsNullOrEmpty(title))
            {
                td.Attributes["title"] = title;
            }
            html.ViewContext.Writer.Write(td.ToString(TagRenderMode.StartTag));
            var element = new TdElement(html.ViewContext);
            return element;
        }
    }
