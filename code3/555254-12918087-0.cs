    using System;
    using System.Web;
    
    namespace FlixPicks.Web.Extensions
    {
        public static class HttpContextExtensions
        {
            public static string SiteRootPath(this HttpContext context)
            {
                if (context == null || context.Request == null) { return null; }
    
                return context.Request.Url.SiteRootPath(context.Request.ApplicationPath);
            }
    
            public static string SiteRootPath(this HttpContextBase context)
            {
                return context.Request.Url.SiteRootPath(context.Request.ApplicationPath);
            }
    
            private static string SiteRootPath(this Uri url, string applicationPath)
            {
                if (url == null) { return null; }
    
                // Formatting the fully qualified website url/name.
                string appPath = string.Format(
                            "{0}://{1}{2}{3}",
                            url.Scheme,
                            url.Host,
                            url.Port == 80 ? string.Empty : ":" + url.Port,
                            applicationPath);
    
                // Remove ending slash(es) if one or more exists to consistently return
                // a path without an ending slash.  Could have just as well choosen to always include an ending slash.
                while (appPath.EndsWith("/") || appPath.EndsWith("\\"))
                {
                    appPath = appPath.Substring(0, appPath.Length - 1);
                }
    
                return appPath;
            }
        }
    }
