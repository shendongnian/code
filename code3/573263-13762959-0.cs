	protected void Application_BeginRequest(object sender, EventArgs ea) {
		string siteDisabledFilePath = "/SiteDisabled.htm";
		
		if (CachingAndUtils.IsSiteDisabled && HttpContext.Current.Request.FilePath != siteDisabledFilePath) {
			HttpContext.Current.Response.Redirect(siteDisabledFilePath);
		}
	}
