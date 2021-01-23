    private async Task<List<Cookie>> GetCookies(string url)
    {
    	var cookieContainer = new CookieContainer();
    	var uri = new Uri(url);
    	using (var httpClientHandler = new HttpClientHandler
    	{
    		CookieContainer = cookieContainer
    	})
    	{
    		using (var httpClient = new HttpClient(httpClientHandler))
    		{
    			await httpClient.GetAsync(uri);
    			return cookieContainer.GetCookies(uri).Cast<Cookie>().ToList();
    		}
    	}
    }
