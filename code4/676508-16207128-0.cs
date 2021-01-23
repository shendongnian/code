    public async Task<Result> SomeMethod()
    {
       var result = new TaskCompletionSource<Result>();
       library.WorkDone += (data) =>
                                    {
                                        result.SetResult(data);
                                    };
       library.DoWork();
       return await result.Task;
    }
