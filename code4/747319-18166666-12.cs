    private Task<bool> login(String username, String password)
    {
        return login(username, password, CancellationToken.None);
    }
    private async Task<bool> login(String username, String password, CancellationToken cancelToken)
    {
        var tcs = new TaskCompletionSource<bool>();
        // Make the login request
        var request = new RestSharp.RestRequest("/accounts/login/", RestSharp.Method.POST);
        request.AddParameter("username", username);
        request.AddParameter("password", password);
        var asyncHandle = client.ExecuteAsync(request, (response, handle) =>
            {
                try
                {
                    // Return loggin status
                    var dom = response.Content;
                    tcs.TrySetResult(dom["html"].HasClass("logged-in")); 
                }
                catch(Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            });
        //if the token is canceled it will call `asyncHandle.Abort()` for us.
        using(cancelToken.Register(() =>
            {
               if(tcs.TrySetCanceled(cancelToken))
                   asyncHandle.Abort();
            }))
        {
            return await tcs.Task;
        }
    }
