    private Task<bool> login(String username, String password)
    {
        return login(username, password, CancellationToken.None);
    }
    private Task<bool> login(String username, String password, CancellationToken cancelToken)
    {
        var tcs = new TaskCompletionSource<bool>();
        // Make the login request
        var request = new RestSharp.RestRequest("/accounts/login/", RestSharp.Method.POST);
        request.AddParameter("username", username);
        request.AddParameter("password", password);
        var asyncHandle = client.ExecuteAsync(request, (response, handle) =>
            {
                // Return loggin status
                var dom = response.Content;
                
                //dom["html"] did not have a .HasClass in my tests, so this code may need work.
                tcs.SetResult(dom["html"].HasClass("logged-in")); 
            });
        //if the token is canceled it will call `asyncHandle.Abort()` for us.
        cancelToken.Register(asyncHandle.Abort);
        return tcs.Task;
    }
