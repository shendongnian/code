    public static async Task<Foo> GetFooAsync()
    {
        // Start asynchronous operation(s) and return associated task.
        ...
    }
    public static Foo CallGetFooAsyncAndWaitOnResult()
    {
        var task = GetFooAsync();
        task.Wait(); // Blocks current thread until GetFooAsync task completes
                     // For pedagogical use only: in general, don't do this!
        var result = task.Result;
        return result;
    }
