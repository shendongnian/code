    void appliaction_BeginRequest(object sender, EventArgs e)
     {
        HttpRequest request = sender as HttpRequest;
         if（request.Url.Host.Contains("site1.com"))
         {
            request.RequestContext.HttpContext.Server.Transfer("site1.com/site1", true);
        }
                        
      }
