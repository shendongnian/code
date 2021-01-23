    public static class HtmlHelperExtensions
    {
        public static bool IsAdmin(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.HttpContext.Current.User.IsInRole("admin");
        }
    }
