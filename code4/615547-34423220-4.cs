    public Foo GetFooSynchronous
    {
        var foo = new Foo();
        GetInfoAsync()  // ContinueWith doesn't run until the task is complete
            .ContinueWith(task => foo.Info = task.Result);
        return foo;
    }
    
    private async Task<string> GetInfoAsync
    {
        return await ExternalLibraryStringAsync().ConfigureAwait(false);
    }
