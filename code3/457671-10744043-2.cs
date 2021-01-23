    using (var client = new HttpClient())
    {
    	using (var content = new MultipartFormDataContent())
    	{
    		var values = new[]
    		{
    			new KeyValuePair<string, string>("Foo", "Bar"),
    			new KeyValuePair<string, string>("More", "Less"),
    		};
    
    		foreach (var keyValuePair in values)
    		{
    			content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
    		}
    
    		var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(fileName));
    		fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    		{
    			FileName = "Foo.txt"
    		};
    		content.Add(fileContent);
    
    		var requestUri = "/api/action";
    		var result = client.PostAsync(requestUri, content).Result;
    	}
    }
