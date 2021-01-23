    var nameValueCollection = new NameValueCollection
	{
		{"client", "x"},
		{"text", HttpUtility.UrlEncode(text)},
		{"hl", "en"},
		{"sl", fromLanguage},
		{"tl", toLanguage},
		{"ie", "UTF-8"},
		{"oe", "UTF-8"}
	};
	string htmlResult;
	using (var wc = new WebClient())
	{
		wc.Encoding = Encoding.UTF8;
		wc.QueryString = nameValueCollection;
		htmlResult = wc.DownloadString(GoogleAddress);
	}
