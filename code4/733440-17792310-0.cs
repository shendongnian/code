    public Task<string> LoginAsync(String username, String password)
    {
        var results = new TaskCompletionSource<string>();
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("user", username);
        parameters.Add("pass", password);
        PostClient client = new PostClient(parameters);
        client.DownloadStringCompleted += (senders, ex) =>
            {
                if (ex.Error == null)
                {
                    results.TrySetResult(ex.Result);
                }
                else
                {
                    results.TrySetException(ex.Error); // Set the exception
                }
            };
        client.DownloadStringAsync(new Uri("http://inkyapps.mobilemp.net/scripts/PHP/socialnet/login.php", UriKind.Absolute));
        return results.Task;
    }
