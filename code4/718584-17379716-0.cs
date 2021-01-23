    public static class Utilities
    {
        public static string GetAbsoluteURL(string relativePath)
        {
            return new Uri(HttpContext.Current.Request.Url, VirtualPathUtility.ToAbsolute(relativePath)).AbsoluteUri;
        }
    }
