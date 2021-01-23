    namespace System.Web.Mvc
    {
        public static class HtmlExtensions
        {
            public static string AbsoluteAction(this UrlHelper url, string action, string controller)
            {
                Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
                string absoluteAction = string.Format("{0}://{1}{2}",
                                                      requestUrl.Scheme,
                                                      requestUrl.Authority,
                                                      url.Action(action, controller));
                return absoluteAction;
            }
        }
    }
