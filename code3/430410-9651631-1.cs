    const string absolutePageUrl = "http://spsite:5000/Pages/SomePage.aspx";
        
    foreach (SPUser user in SPContext.Current.Site.RootWeb.AllUsers.Cast<SPUser>())
    {
    	if (!user.LoginName.StartsWith("DOMAIN NAME"))
    		continue;
    	
    	using (SPSite site = new SPSite(absolutePageUrl, user.UserToken))
    	using (SPWeb web = site.OpenWeb())
    	{
    		var mgr = web.GetLimitedWebPartManager(pageUrl, PersonalizationScope.User);
    		var webPart = mgr.WebParts.OfType<MyWebPart>().FirstOrDefault();
    		var prop = webPart.CustomProp;
    	}
    }
