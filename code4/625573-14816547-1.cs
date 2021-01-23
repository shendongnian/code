    public static class UrlExtensions
    {
        public static string ToAbsoluteUrl(this string relativeUrl) {
             string http = "http" + Request.IsSecureConnection ? "s" : string.Empty;
             string host = Request.Url.Host;
             string url = Page.ResolveUrl(relativeUrl);
    
             return string.Format("{0}://{1}{2}", http, host, url);    
        }
    }
