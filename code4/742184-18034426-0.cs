	static void Main(string[] args)
	{
		WebClient client = new WebClient();
		string code = client.DownloadString("http://oddsportal.com/feed/prematch/1-1-hSpbs4Cd-1-2.dat");
		client.Dispose();
		code = code.Replace("-|-", string.Empty);
		JObject json = JsonConvert.DeserializeObject<JObject>(code);
			
		int one = (int)json["d"]["bt"];
		Debug.Assert(one == 1);
	}
