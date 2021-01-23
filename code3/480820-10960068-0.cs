	try
	{
		var http = (HttpWebRequest)WebRequest.Create("youtube api");
		using (var resp = http.GetResponse())
		{
			//Handle api response
		}
	}
	catch (WebException we)
	{
		if (we.Response == null)
			throw; //Rethrow because it doesn't have a body.
		var resp = (HttpWebResponse)we.Response;
		if (resp.StatusCode != HttpStatusCode.Forbidden)
			throw; //We are only handling forbidden, rethrow other statuses.
		using (var sr = new StreamReader(resp.GetResponseStream()))
		{
			var xml = sr.ReadToEnd();
			//Log xml here
		} 
	}
