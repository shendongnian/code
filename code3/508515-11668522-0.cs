    [Flags]
    public enum AuthorizeFlags
    {
        Administrator = 1,
        L1 = 2,
        L2 = 4
    }
    public static class UrlHelperExtensions
    {
        public static MvcHtmlString CustomUrl(this UrlHelper urlHelper, string controllerName, string actionName, object routeValues = null)
        {
            var actionFlag = CustomMethodForRetrievingFlags(actionName);
            var userFlag = CustomMethodForRetrievingUserFlag();
            if ((actionFlag & userFlag) == userFlag)
            {
                return new MvcHtmlString(urlHelper.Action(actionName, controllerName, routeValues));
            }
            return new MvcHtmlString(String.Empty);
        }
        private static AuthorizeFlags CustomMethodForRetrievingUserFlag()
        {
            return AuthorizeFlags.L2;
        }
        private static AuthorizeFlags CustomMethodForRetrievingFlags(string actionName)
        {
            return (AuthorizeFlags.Administrator | AuthorizeFlags.L1); // test stub
        }
    }
