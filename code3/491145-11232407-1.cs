	public static CookieCollection FixCookies(CookieCollection collection)
	{
		foreach (Cookie cookie in collection)
		{
			if (string.IsNullOrEmpty(cookie.Path))
				continue;
			int idx = cookie.Path.LastIndexOf('/');
			if (idx == -1)
				continue;
			cookie.Path = cookie.Path.Substring(0, idx);
		}
		return collection;
	}
	[STAThread]
	private static void Main(string[] args)
	{
		var http = (HttpWebRequest)WebRequest.Create("http://localhost/test/test.php");
		http.CookieContainer = new CookieContainer();
		var resp = (HttpWebResponse)http.GetResponse();
		http.CookieContainer.Add(FixCookies(resp.Cookies));
	}
