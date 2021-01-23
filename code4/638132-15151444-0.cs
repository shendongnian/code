    public static async Task<Foo> GetFooAsync()
    {
        ...
    }
    public static Foo CallGetFooAsyncAndWaitOnResult()
    {
        var task = GetFooAsync();
        task.Wait();
        var result = task.Result;
        return result;
    }
