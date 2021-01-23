    public static class HtmlExtensions
    {
        public static void EditOrDelete(this HtmlHelper html)
        {
            using (html.BeginForm())
            {
                html.ViewContext.Writer.Write("additional fields");
            }
        }
    }
