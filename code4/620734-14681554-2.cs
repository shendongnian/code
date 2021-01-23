     public static string GetBaseUrl()
            {
                HttpContext context = HttpContext.Current;
                string baseUrl = String.Format("{0}://{1}{2}/", 
                context.Request.Url.Scheme,
                context.Request.Url.Authority,
                context.Request.ApplicationPath.TrimEnd('/'));
                return baseUrl;
            } 
