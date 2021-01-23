        var feed = new List<RssNews>();
    	using (var webClient = new WebClient())
    	{
    
    		string result = webClient.DownloadString(url);
    		using (var stringReader = new StringReader(result))
    		{
    			var serializer = new XmlSerializer(feed.GetType());
    			feed = (List<RssNews>)serializer.Deserialize(stringReader);
    		}
    	}
    	return feed;
