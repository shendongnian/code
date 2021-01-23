    public static class HtmlHelperCustom
    {
        public static bool IsAccessibleToUser(this HtmlHelper helper, String element)
        {
            var user = (UserModel)HttpContext.Current.Session["currentUser"];
            return user.rights.Contains(element);
        }
    }
