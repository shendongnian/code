    public static class HtmlHelperExtensions
    {
        public static MvcDiv BeginDiv(this HtmlHelper htmlHelper)
        {
            return new MvcDiv(htmlHelper.ViewContext);
        }
    }
