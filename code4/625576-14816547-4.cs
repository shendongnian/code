    public static class UrlExtension
    {
        public static string ToAbsoluteUrl(this string relativeUrl, HttpContext httpContext)
        {
            string http = "http" + (httpContext.Request.IsSecureConnection ? "s" : string.Empty);
            string host = httpContext.Request.Url.Host;
            string port = httpContext.Request.Url.Port == 80 ? string.Empty : string.Format(":{0}", httpContext.Request.Url.Port);            
            return string.Format("{0}://{1}{2}{3}", http, host, port, relativeUrl);
        }
    }
