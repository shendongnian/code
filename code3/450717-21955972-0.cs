	private void LoadTraditionalWay(String url)
	{
		WebRequest myWebRequest = WebRequest.Create(url);
		WebResponse myWebResponse = myWebRequest.GetResponse();
		Stream ReceiveStream = myWebResponse.GetResponseStream();
		Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
		TextReader reader = new StreamReader(ReceiveStream, encode);
		HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
		doc.Load(reader);
		reader.Close();
	}
