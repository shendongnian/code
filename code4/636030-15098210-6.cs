	void Main()
	{
		{...}
		var request = (HttpWebRequest)WebRequest.Create(uri);
		request.Accept = acceptHeader;
		var response = await request.DownloadStringTaskAwait();
		DoSomeStuff(response);
	}
	
	// Define other methods and classes here
	public static class HttpWebRequestExtension
	{
		public async Task<string> DownloadStringTaskAwait(this HttpWebRequest request)
		{
			var response = await Task.Factory.FromAsync(
								request.BeginGetResponse,
								request.EndGetResponse,
								null);
			using (var sr = new StreamReader(response.GetResponseStream()))
			{
				return sr.ReadToEnd();
			}
		}	                  
	}
