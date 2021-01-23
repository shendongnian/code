	var request = WebRequest.Create(url);
	request.ContentType = "application/json; charset=utf-8";
	string json;
	using (var response = request.GetResponse())
	{
		using (var sr = new StreamReader(response.GetResponseStream()))
		{
			json = sr.ReadToEnd();
		}
	}
