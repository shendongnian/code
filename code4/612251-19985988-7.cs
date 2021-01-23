    public async Task MyMethodAsync()
    {
        Task<int> longRunningTask = LongRunningOperationAsync();
        // independent work which doesn't need the result of LongRunningOperationAsync can be done here
        //and now we call await on the task 
        int result = await longRunningTask;
        //use the result 
        Console.WriteLine(result);
    }
    public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
    {
        await Task.Delay(1000); //1 seconds delay
        return 1;
    }
