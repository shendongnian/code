	HttpWebRequest webreq = ((HttpWebRequest) (WebRequest.Create(sourceUri)));
	CookieContainer cookies = new CookieContainer();
	var postdata = Encoding.ASCII.GetBytes("cn=MyCookieName&cv=MyCookieValue");
	webreq.CookieContainer = cookies;
	webreq.Method = "POST";
	webreq.ContentLength = postdata.Length;
	webreq.ContentType = "application/x-www-form-urlencoded";
	Stream webstream = webreq.GetRequestStream();
	webstream.Write(postdata, 0, postdata.Length);
	webstream.Close();
	using (WebResponse response = webreq.GetResponse())
	{
		webstream = response.GetResponseStream();
		using (StreamReader reader = new StreamReader(webstream))
		{
			String responseFromServer = reader.ReadToEnd();
			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.Load(new MemoryStream(Encoding.ASCII.GetBytes((responseFromServer))));
			var node =
				doc.DocumentNode.SelectNodes("//div").Single(n => n.InnerText.StartsWith("\r\nNumber of cookies received:"));
			Debug.Assert(int.Parse(node.InnerText.Split(' ')[4]) == 1);
		}
	}
