    public static async Task<int> SumTwoOperationsAsync()
    {
        var firstTask = GetOperationOneAsync();
        var secondTask = GetOperationTwoAsync();
        return await firstTask + await secondTask;
    }
    // These are just examples - you don't need to translate them.
    private async Task<int> GetOperationOneAsync()
    {
        await Task.Delay(500); // Just to simulate an operation taking time
        return 10;
    }
    private async Task<int> GetOperationTwoAsync()
    {
        await Task.Delay(100); // Just to simulate an operation taking time
        return 5;
    }
