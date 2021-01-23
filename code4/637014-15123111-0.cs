    TaskCompletionSource<bool> IsSomethingLoading = new TaskCompletionSource<bool>();
    SomeData TheData;
    
    public async Task<SomeData> GetTheData()
    {
       await IsSomethingLoading.Task;
       return TheData;
    }
