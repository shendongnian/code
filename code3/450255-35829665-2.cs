    public async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : class, new()
    {
        var client = new RestClient
        {
            BaseUrl = _baseUrl,
            Authenticator = new HttpBasicAuthenticator(_useraname, _password),
            Timeout = 3000,
        };
        
        var tcs = new TaskCompletionSource<T>();
        client.ExecuteAsync<T>(request, restResponse =>
        {
            if (restResponse.ErrorException != null)
            {
                const string message = "Error retrieving response.";
                throw new ApplicationException(message, restResponse.ErrorException);
            }
            tcs.SetResult(restResponse.Data);
        });
        return await tcs.Task as IRestResponse<T>;
    }
