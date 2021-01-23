    public static class HtmlHelperExtensions
    {
        private class Menu : IDisposable
        {
            private readonly TextWriter _writer;
            public Menu(TextWriter writer)
            {
                _writer = writer;
            }
    
            public void Dispose()
            {
                _writer.Write("</li>");
            }
        }
    
        public static IDisposable BeginLeftMenu(this HtmlHelper htmlHelper)
        {
            var writer = htmlHelper.ViewContext.Writer;
            writer.Write("<li>");
            return new Menu(writer);
        }
    }
