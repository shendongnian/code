    IList<MyClass> myClassList = null;
	var request = WebRequest.Create(url);
	request.ContentType = "application/json; charset=utf-8";
	string json;
	using (var response = request.GetResponse())
	{
		using (var sr = new StreamReader(response.GetResponseStream()))
		{
	        json = sr.ReadToEnd();
			var javaScriptSerializer = new JavaScriptSerializer();
            myClassList = javaScriptSerializer.Deserialize<List<MyClass>>(json);
		}
	}
