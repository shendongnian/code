    public async Task MyMethodAsync()
    {
        Task<int> longRunningTask = LongRunningOperationAsync();
        //indeed you can do independent to the int result work here 
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
