    public async Task<HttpResponseMessage> PostResult(string url, ResultObject resultObject)
    {
	    using (var client = new HttpClient())
	    {
		    HttpResponseMessage response = new HttpResponseMessage();
		    try
		    {
			    response = await client.PostAsJsonAsync(url, resultObject);
		    }
		    catch (Exception ex)
	    	{
			    throw ex
		    }
		    return response;
	     }
    }
