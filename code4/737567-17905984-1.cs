      <% HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
       HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
       HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
       HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
       HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
       HttpContext.Current.Response.Cache.SetNoStore();
       Response.Cache.SetExpires(DateTime.Now);
       System.Web.HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
       Response.Cache.SetValidUntilExpires(true);
       Response.Buffer = true;
       Response.ExpiresAbsolute = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
       Response.Expires = 0;
       Response.CacheControl = "no-cache";
       Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-4)); 
       Response.ExpiresAbsolute = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
       Response.AppendHeader("Pragma", "no-cache");
       Response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate, post-check=0, pre-check=0");
    %>  
    <script language="javascript" type="text/javascript">
        window.onbeforeunload = function () {
            // This function does nothing.  It won't spawn a confirmation dialog   
            // But it will ensure that the page is not cached by the browser.
        }  
    </script>
