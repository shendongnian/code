    public static class HtmlHelperCustom
    {
        public static bool IsAccessibleToUser(this HtmlHelper helper, String element)
        {
            UserModel user = (UserModel)HttpContext.Current.Session["user"];
            return user.rights.Contains(element);
        }
    }
