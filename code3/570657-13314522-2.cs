    public string GetPageData(string link)
    {
    	_request = new HttpRequestMessage(HttpMethod.Get, link);
    	_request.Headers.Add("User-Agent", "Chrome/21.0.1180.89");
    	_request.Headers.Add("Accept", "text/html");
    
    
    	var readTask = _client.GetStringAsync(link);
    	readTask.Wait();
    	return readTask.Result;
    }
