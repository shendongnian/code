    public Task<string> GetSomeDataAsync(CancellationToken cancellationToken = null)
    {
        return Task<string>.Factory.StartNew(() =>  "foo", cancellationToken);
    }
    // NOTE: no need to append Sync to the method name, redundant.
    public string GetSomeData()
    {
        var task = GetSomeDataAsync();
        task.ConfigureAwait(continueOnCapturedContext: false);
        return task.Result;
    }
