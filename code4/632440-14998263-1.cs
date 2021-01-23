    protected void Application_BeginRequest(Object sender, EventArgs e)
    {   
        var SubDomain = GetSubDomain(HttpContext.Current.Request.Host);
        // this is a simple example, you can place your variables base on subdomain
        if(!String.IsNullOrEmpty(SubDomain))
           RewritePath(HttpContext.Current.Request.Path + SubDomain + "/", false);  
    }
    // from : http://madskristensen.net/post/Retrieve-the-subdomain-from-a-URL-in-C.aspx
    private static string GetSubDomain(Uri url)
    {
      string host = url.Host;
      if (host.Split('.').Length > 1)
      {
        int index = host.IndexOf(".");
        return host.Substring(0, index);
      }
     
      return null;
    }
