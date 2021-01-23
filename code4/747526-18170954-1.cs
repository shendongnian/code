        var tcs1 = new TaskCompletionSource<CsQuery.CQ>();
        var tcs2 = new TaskCompletionSource<bool>();
       
        RestSharp.RestRequest request;
        CsQuery.CQ dom;
        request = new RestSharp.RestRequest("/accounts/login/", RestSharp.Method.GET);
        client.ExecuteAsync(request, (asyncResponse, handle) =>
        {
            tcs1.SetResult(asyncResponse.Content);
        });
		tcs1.Task.ContinueWith( () =>
		{	
			// Get the token needed to make the login request
			dom = tcs1.Task.ToString();
			
			// Other Code
		});
