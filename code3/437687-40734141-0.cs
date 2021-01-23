    WebProxy proxy = new WebProxy()
    {
        UseDefaultCredentials = true,
    };
    HttpClientHandler httpClientHandler = new HttpClientHandler()
    {
        Proxy = proxy,
    };
    using (var client = new HttpClient(httpClientHandler))
    {
        using (var multipartFormDataContent = new MultipartFormDataContent())
        {
    	string body = "Text body of message";
    	var values = new[]
    	{
    		new KeyValuePair<string, string>("body", body),
    		new KeyValuePair<string, string>("group_id", YammerGroupID),
    		new KeyValuePair<string, string>("topic1", "Topic ABC"),
    	};
    	foreach (var keyValuePair in values)
    	{
    	    multipartFormDataContent.Add(new StringContent(keyValuePair.Value), String.Format("\"{0}\"", keyValuePair.Key));
    	}
    	int i = 1;
    	foreach (Picture p in PictureList)
    	{
    	    var FileName = string.Format("{0}.{1}", p.PictureID.ToString("00000000"), "jpg");
    		var FilePath = Server.MapPath(string.Format("~/images/{0}", FileName));
    		if (System.IO.File.Exists(FilePath)) 
    		{
    		    multipartFormDataContent.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(FilePath)), '"' + "attachment" + i.ToString() + '"', '"' + FileName + '"');
    		    i++;
    		}
    	}
    	var requestUri = "https://www.yammer.com/api/v1/messages.json";
    	client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
    	var result = client.PostAsync(requestUri, multipartFormDataContent).Result;
         }
    }
