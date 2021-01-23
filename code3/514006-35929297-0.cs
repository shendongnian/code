    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
      HttpCookie cookie = Request.Cookies["langCookie"];
      if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
      {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
      }
    }
