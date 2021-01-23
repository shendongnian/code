    private bool IsCookiesAllowed()
    {
      string currentUrl = Request.RawUrl;
    
      if (Request.QueryString["cookieCheck"] == null)
      {
        try
        {
          var testCookie = new HttpCookie("SupportCookies", "true");
          testCookie.Expires = DateTime.Now.AddDays(1);
          Response.Cookies.Add(testCookie);
    
          if (currentUrl.IndexOf("?", StringComparison.Ordinal) > 0)
            currentUrl = currentUrl + "&cookieCheck=true";
          else
            currentUrl = currentUrl + "?cookieCheck=true";
    
          Response.Redirect(currentUrl);
        }
        catch
        {
        }
      }
     
      return Request.Cookies.Get("SupportCookies") != null;
    }
