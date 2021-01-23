    public class RedirectInvalidDomainsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Url;
            if (url == null) return;
        
            var host = url.Host;
        
            if (host.Contains("equispot.com") || host.Contains("localhost")) return;
            string subdomain = GetSubDomain(host);
        
            Guid guid;
            if (Guid.TryParseExact(subdomain, "N", out guid)) 
            {
                // this is a staging domain, it's okay
                return;
            }
      
            // Invalid domain - 301 redirect
            UriBuilder builder = new UriBuilder(url) {Host = "www.equispot.com"};
            filterContext.Result = new RedirectResult(builder.Uri.ToString(), true);
        }
       
        // This isn't perfect, but it works for the sub-domains Azure provides
        private static string GetSubDomain(string host)
        {
            if (host.Split('.').Length > 1)
            {
                int index = host.IndexOf(".");
                return host.Substring(0, index);
            }
        
             return null;
         }
    }
