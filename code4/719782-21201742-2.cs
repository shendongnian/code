    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace utest1.umbracoExtensions.helpers
    {
        public class CDNImage
        {
            public static string ConvertUrlToCDN(string source)
            {
                if (String.IsNullOrEmpty(source))
                {
                    return null;
                }
    
                var cdnUrl = System.Configuration.ConfigurationManager.AppSettings["CDNPath"];
                var cdnOn = System.Configuration.ConfigurationManager.AppSettings["CDNEnabled"];
    
                if (cdnOn == "true")
                {
                    /* 
                     *  check if the url is absolute or not and whether it should be intercepted - eg. an external image url
                     *  if it's absolute you'll need to strip out everything before /media...
                     */
    
                    if (source.Contains(GetBaseUrl()))
                    {
                        source = StripBaseUrl(source);
                    }
    
                }
    
                return source;
            }
    
            private static string GetBaseUrl()
            {
                var url = System.Web.HttpContext.Current.Request.Url;
                var baseUrl = url.Scheme + "//" + url.Host;
    
                if (url.Port != 80 && url.Port != 443)
                {
                    baseUrl += ":" + url.Port;
                }
    
                return baseUrl;
            }
    
            private static string StripBaseUrl(string path)
            {
                return path.Replace(GetBaseUrl(), String.Empty);
            }
        }
    }
