    public static class UrlHelpers
    {
        public static string Content(this UrlHelper urlHelper,
                                     string formatPath, 
                                     params object[] args)
        {
            return urlHelper.Content(String.Format(formatPath, args));
        }
    }
