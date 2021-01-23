    public static class HtmlExtensions
    {
        public static IHtmlString Menu(this HtmlHelper htmlHelper)
        {
            var user = htmlHelper.ViewContext.HttpContext.User;
            if (user.IsInRole("Admin"))
            {
                return new HtmlString("Admin menu");
            }
            if (user.Identity.IsAuthenticated)
            {
                return new HtmlString("Normal menu");
            }
            return htmlHelper.ActionLink("Login", "Logon", "Account");
        }
    }
