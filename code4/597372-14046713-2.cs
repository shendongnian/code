    public async Task Index()
    {
        var a = AsyncMethod();
        var b = AsyncMethod();
        await Task.WhenAll(a, b);
    }
