			var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://google.com");
			var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
			var s = myHttpWebResponse.GetResponseStream();
			
			var doc = new HtmlDocument();
			doc.Load(s);
			foreach (var link in doc.DocumentNode.SelectNodes("//a"))
			{
				var att = link.Attributes["href"].Value;
				link.Attributes["href"].Value = "http://ahmadalli.somee.com/default.aspx?url=" + att;
				Console.WriteLine(link.Attributes["href"].Value);
			}
