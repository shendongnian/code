    public static class UrlExtension
    {
        public static string ToAbsoluteUrl(this string relativeUrl, HttpContext httpContext)
        {
            string http = "http" + (httpContext.Request.IsSecureConnection ? "s" : string.Empty);
            string host = httpContext.Request.Url.Host;
            string url = relativeUrl;
            return string.Format("{0}://{1}{2}", http, host, url);
        }
    }
