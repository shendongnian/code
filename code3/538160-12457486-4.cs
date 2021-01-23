    async Task<int> TaskOfTResult_MethodAsync()
    {
        int hours;
        // . . .
        // Return statement specifies an integer result.
        return hours;
    }
    // Calls to TaskOfTResult_MethodAsync
    Task<int> returnedTaskTResult = TaskOfTResult_MethodAsync();
    int intResult = await returnedTaskTResult;
    // or, in a single statement
    int intResult = await TaskOfTResult_MethodAsync();
    
