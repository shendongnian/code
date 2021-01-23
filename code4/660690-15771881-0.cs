        public static string GetAbsoluteURL(this RouteCollection routes, RequestContext context, RouteValueDictionary values, HttpProtocolType httpProtocol)
        {
            string host;
 
            if (context.HttpContext.Request.Url != null)
            {
                host = context.HttpContext.Request.Url.Authority;
            }
            else
            {
                host = context.HttpContext.Request.UrlReferrer.Host;
            }
 
            string virtualPath = routes.GetVirtualPath(context, "Default", values).VirtualPath;
 
            string protocol = httpProtocol == HttpProtocolType.HTTP ? "http" : "https";
 
            return string.Format("{0}://{1}{2}", protocol, host, virtualPath);
        }
