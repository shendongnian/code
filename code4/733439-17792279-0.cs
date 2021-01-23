    public Task<string> Login(String username, String password)
    {
        var tcs = new TaskCompletionSource<string>();
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("user", username);
        parameters.Add("pass", password);
        PostClient client = new PostClient(parameters);
        client.DownloadStringCompleted += (senders, ex) =>
        {
            if (ex.Error == null)
            {
                //Process the result...
                tcs.TrySetResult(ex.Result);
            }
            else
            {
                string errorMessage = "An error occurred. The details of the error: " + ex.Error;
                //todo use a more derived exception type
                tcs.TrySetException(new Exception(errorMessage));
            }
        };
        client.DownloadStringAsync(new Uri("http://inkyapps.mobilemp.net/scripts/PHP/socialnet/login.php", UriKind.Absolute));
        return tcs.Task;
    }
