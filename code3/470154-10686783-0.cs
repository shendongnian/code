	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
	System.Net.CredentialCache credentialCache = new System.Net.CredentialCache();
	credentialCache.Add(
		new System.Uri(apiUrl),
		"Basic",
		new System.Net.NetworkCredential(basicAuthUserName, basicAuthPassword)
	);
	request.PreAuthenticate = true;
	request.Credentials = credentialCache;
