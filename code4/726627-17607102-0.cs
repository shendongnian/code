    string result = string.Empty;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            request.Method = "GET";
            try
            {
                using (var stream = request.GetResponse().GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
           HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
           htmlDoc.LoadHtml(result);
