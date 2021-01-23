    public Task<string> GetSomeDataAsync(CancellationToken cancellationToken = null)
    {
        return Task<string>.Factory.StartNew(() =>  "foo", cancellationToken);
    }
    public string GetSomeDataSync()
    {
        var task = GetSomeDataAsync();
        task.ConfigureAwait(continueOnCapturedContext: false);
        return task.Result;
    }
