	public static string DownloadString(string url, Encoding encoding, IDictionary<string, string> cookieNameValues)
	{
		using (var webClient = new WebClient())
		{
			var uri = new Uri(url);
			var webRequest = WebRequest.Create(uri);
			foreach(var nameValue in cookieNameValues)
			{
				webRequest.TryAddCookie(new Cookie(nameValue.Key, nameValue.Value, "/", uri.Host));
			}                
			var response = webRequest.GetResponse();
			var receiveStream = response.GetResponseStream();
			var readStream = new StreamReader(receiveStream, encoding);
			var htmlCode = readStream.ReadToEnd();                
			return htmlCode;
		}
	}   
