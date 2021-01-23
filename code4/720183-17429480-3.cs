    public Task<string> GetAuthorizationUrl()
    {
        var tcs = new TaskCompletionSource<string>();   
        _dropNetClient.GetTokenAsync(
            login => tcs.SetResult(_dropNetClient.BuildAuthorizeUrl
                                        _authorizationCallback.ToString()),
            exception => tcs.SetException(exception));
        return tcs.Task;
    }
