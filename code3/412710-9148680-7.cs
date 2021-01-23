    public static class HtmlExtensions
    {
        public static TextHelper Text(this HtmlHelper htmlHelper)
        {
            return new TextHelper(htmlHelper.ViewContext);
        }
    }
