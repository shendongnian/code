    void M()
    {
        Task tx = GetATask();
        tx.Wait();
    }
    async Task GetATask()
    {
        Task ty = DoFileSystemThingAsync();
        await ty;
        DoSomethingElse();
    }
