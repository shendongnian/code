	Uri sourceUri = new Uri(@"http://www.html-kit.com/tools/cookietester/");
	WebClientEx webClientEx = new WebClientEx();
	webClientEx.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
	webClientEx.UploadString(sourceUri, "cn=MyCookieName&cv=MyCookieValue");
	var text = webClientEx.DownloadString(sourceUri);
	var doc = new HtmlAgilityPack.HtmlDocument();
	doc.Load(new MemoryStream(Encoding.ASCII.GetBytes((text))));
	var node = doc.DocumentNode.SelectNodes("//div").Single(n => n.InnerText.StartsWith("\r\nNumber of cookies received:"));
	Debug.Assert(int.Parse(node.InnerText.Split(' ')[4]) == 1);
