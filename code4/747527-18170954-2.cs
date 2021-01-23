    public async Task<bool> login()
    {
	    var tcs1 = new TaskCompletionSource<string>();
		     
	    RestSharp.RestRequest request;
        request = new RestSharp.RestRequest("/accounts/login/", RestSharp.Method.GET);
        client.ExecuteAsync(request, (asyncResponse, handle) =>
        {
            tcs1.SetResult(asyncResponse.Content);
        });
	
	    await tcs1.Task;
	
        // Other Code ...
	
	    return true;
    } 
