	HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
	request.Method = "GET";
	request.Timeout = System.Threading.Timeout.Infinite;
	request.Credentials = new CredentialCache
	{
		{ new Uri(url), "NTLM", new NetworkCredential(username, password, domain) }
	};
	request.Headers.Add("Authorization", GetAuthorization(username, password, domain));
	request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; zh-TW; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12 GTB7.1 ( .NET CLR 3.5.30729)";
	request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
	request.CookieContainer = new CookieContainer();
	HttpWebResponse response = request.GetResponse() as HttpWebResponse;
