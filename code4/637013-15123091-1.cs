    public Task<SomeData> GetTheData()
    {
        TaskCompletionSource<SomeData> tcs = new TaskCompletionSource<SomeData>();
        SomeObject worker = new SomeObject();
        worker.WorkCompleted += result => tcs.SetResult(result);
        worker.DoWork();
        return tcs.Task;
    }
