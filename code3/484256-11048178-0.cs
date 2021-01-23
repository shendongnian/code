    public static class UrlHelperExtensions
    {
        private static string GetCookieOrDefault(HttpRequestBase request, string name)
        {
            return request.Cookies[name] == null ? "" : request.Cookies[name].Value;
        }
        public static string MRUrl(this UrlHelper url)
        {
            var request = url.RequestContext.HttpContext.Request;
            return url.Action("Index", "MR", new
            {
                mr1 = GetCookieOrDefault(request, "MR1"),
                mr2 = GetCookieOrDefault(request, "MR2"),
                mr3 = GetCookieOrDefault(request, "MR3")
            });
        }
    }
