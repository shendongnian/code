     protected void Page_Load(object sender, EventArgs e)
      {
           Response.Cache.SetCacheability(HttpCacheability.NoCache); 
           Response.Cache.SetAllowResponseInBrowserHistory(false);
    
            // or else you can do like this 
    
           Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1;
            Response.CacheControl = "No-cache";
      }
