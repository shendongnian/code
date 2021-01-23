	bool StreamOnline = false;
	using (var w = new WebClient())
	{
		var jsonData = w.DownloadData("https://api.twitch.tv/kraken/streams/" +  + chan);
		var s = new DataContractJsonSerializer(typeof(RootObject));
		using (var ms = new MemoryStream(jsonData))
		{
			var obj = (RootObject)s.ReadObject(ms);
			StreamOnline = obj.stream == null;
		}
		
	}
	return StreamOnline;
