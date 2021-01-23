    public static CustomHttpContext Initialize(HttpContextBase httpContextBase)
	{
		Guard.IsNotNull(httpContextBase, "httpContext");
		// initialize only once
		if (! httpContextBase.Items.Contains(key))
		{
			CustomHttpContext newCustomHttpContext = new CustomHttpContext();
			httpContextBase.Items[key] = newCustomHttpContext;
			return newCustomHttpContext;
		}
		return Get(httpContextBase);
	}
