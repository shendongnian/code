    public static class AuthHelper
    {
        public static bool IsUserAdmin(this HtmlHelper helper)
        {
            return helper.ViewContext.HttpContext.User.IsInRole("Administrator");
        }
    }
