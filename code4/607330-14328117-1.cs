    public static class HtmlExtensions
    {
        public static bool ShouldShowButtons(this HtmlHelper html)
        {
            return html.ViewContext.HttpContext.User.IsInRole("UserType1");
        }
    }
