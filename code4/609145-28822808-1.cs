	var emailBody = TemplateManager.GetTemplate(EmailTemplateType.ForgotPassword, new
	{
		SiteUrl = Url.Action(MVC.Home.Index(), protocol: Request.Url.Scheme),
		SiteFriendlyName = SiteSettings.Instance.DomainName.FriendlyName,
		PasswordResetLink = Url.Action(MVC.Account.ActionNames.ResetPassword, MVC.Account.Name, new { userId = user.Id, code = code }, protocol: Request.Url.Scheme),
		NotRequestedUrl = Url.Action(MVC.Account.ActionNames.PasswordResetNotReqeuested, MVC.Account.Name, new { userId = user.Id, requesterIpAddress = WebUtils.GetClientIPAddress(), code = code }, protocol: Request.Url.Scheme)
	},
    /* this setting allows me to disable caching during development */
	!SiteSettings.Instance.EmailSettings.DebugEmailTemplates );
	
	// I could also have a button on an admin page that executed this code to manually reset the cache in production.
	TemplateManager.ResetCache();
