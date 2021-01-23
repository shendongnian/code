    public Foo GetFooSynchronous()
    {
        var foo = new Foo();
        foo.Info = GetInfoAsync.Result;  // often deadlocks in ASP.NET
        return foo;
    }
    private async Task<string> GetInfoAsync()
    { 
        return await ExternalLibraryStringAsync().ConfigureAwait(false);
    }
