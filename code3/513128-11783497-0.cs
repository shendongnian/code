    public async Task<string> GetSomeData(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        var initialData = await SomeOtherMethodWhichReturnsTask(token);
        string result = await initialData.MethodWhichAlsoReturnsTask(token);
        return result;
    };
