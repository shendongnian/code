    async Task<int> TaskOfTResult_MethodAsync()
    {
        int hours;
        // . . .
        // The body of the method should contain one or more await expressions.
    
        // Return statement specifies an integer result.
        return hours;
    }
    
        // Calls to TaskOfTResult_MethodAsync from another async method.
    private async void CallTaskTButton_Click(object sender, RoutedEventArgs e)
    {
        Task<int> returnedTaskTResult = TaskOfTResult_MethodAsync();
        int intResult = await returnedTaskTResult;
        // or, in a single statement
        //int intResult = await TaskOfTResult_MethodAsync();
    }
    
    
    
    
    
    
    // Signature specifies Task
    async Task Task_MethodAsync()
    {
        // . . .
        // The body of the method should contain one or more await expressions.
    
        // The method has no return statement.  
    }
    
        // Calls to Task_MethodAsync from another async method.
    private async void CallTaskButton_Click(object sender, RoutedEventArgs e)
    {
        Task returnedTask = Task_MethodAsync();
        await returnedTask;
        // or, in a single statement
        //await Task_MethodAsync();
    }
