    public Task<GetTokenResult> GetAuthorizationUrl()
    {
        var tcs = new TaskCompletionSource<GetTokenResult>();   
        _dropNetClient.GetTokenAsync(
            login => tcs.SetResult(new GetTokenResult { 
                Url = _dropNetClient.BuildAuthorizeUrl(
                          _authorizationCallback.ToString()),
                Success = true
            },
            exception => tcs.SetResult(new GetTokenResult { 
                Error = exception.ToDiagnosticString(),
                Success = true
            });
        return tcs.Task;
    }
