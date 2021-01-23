    public string ResolveClientUrl(string relativeUrl)
    {
    	if (this.DesignMode && this.Page != null && this.Page.Site != null)
    	{
    		IUrlResolutionService urlResolutionService = (IUrlResolutionService)this.Page.Site.GetService(typeof(IUrlResolutionService));
    		if (urlResolutionService != null)
    		{
    			return urlResolutionService.ResolveClientUrl(relativeUrl);
    		}
    	}
    	if (relativeUrl == null)
    	{
    		throw new ArgumentNullException("relativeUrl");
    	}
    	string virtualPathString = VirtualPath.GetVirtualPathString(this.TemplateControlVirtualDirectory);
    	if (string.IsNullOrEmpty(virtualPathString))
    	{
    		return relativeUrl;
    	}
    	string text = this.Context.Request.ClientBaseDir.VirtualPathString;
    	if (!UrlPath.IsAppRelativePath(relativeUrl))
    	{
    		if (StringUtil.EqualsIgnoreCase(text, virtualPathString))
    		{
    			return relativeUrl;
    		}
    		if (relativeUrl.Length == 0 || !UrlPath.IsRelativeUrl(relativeUrl))
    		{
    			return relativeUrl;
    		}
    	}
    	string to = UrlPath.Combine(virtualPathString, relativeUrl);
    	text = UrlPath.AppendSlashToPathIfNeeded(text);
    	return HttpUtility.UrlPathEncode(UrlPath.MakeRelative(text, to));
    }
