    namespace <root app namespace>
    {
        public static class Helpers
        {
            public static string GetThemePath(this HtmlHelper helper)
            {
                return System.Web.Hosting.HostingEnvironment.MapPath("~") + "/path-to-theme";
            }
        }
    }
