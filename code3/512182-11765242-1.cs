	public NameValueCollection LoginToDatrose()
	{
		var loginUriBuilder = new UriBuilder();
		loginUriBuilder.Host = DatroseHostName;
		loginUriBuilder.Path = BuildURIPath(DatroseBasePath, LOGIN_PAGE);
		loginUriBuilder.Scheme = "https";
		var postData = new NameValueCollection();
		postData.Add("LoginName", DatroseUserName);
		postData.Add("Password", DatrosePassword);
		var responseCookies = new NameValueCollection();
		using (var client = new CookiesAwareWebClient())
		{
			client.IgnoreRedirects = true;
			var clientResponse = client.UploadValues(loginUriBuilder.Uri, "POST", postData);
			foreach (var nvp in client.InboundCookies.OfType<Cookie>())
			{
				responseCookies.Add(nvp.Name, nvp.Value);
			}
		}
		return responseCookies;
	}
