    public static async Task<string> CallGET(string requestUri, string id = "")
    {
    	string responseData;
    	using (var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
    	{
    		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    		Uri.TryCreate(new Uri(baseURI), $"{requestUri}{(string.IsNullOrEmpty(id) ? string.Empty : $"/{id}")}", out Uri fullRequestUri);
    		using (var response = await client.GetAsync(fullRequestUri))
    		{
    			responseData = await response.Content.ReadAsStringAsync();
    		}
    		return responseData;
    	}
    }
