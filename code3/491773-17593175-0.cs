    protected void Application_BeginRequest(object sender, EventArgs e) {
       if (Request.Path.Contains("AjaxTestWCFService.svc")) {
          HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.ReadOnly);
       }
    }
