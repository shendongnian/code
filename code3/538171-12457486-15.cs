    private int ResultAsync()
    {
        int? hours = null;
        Task<int> task = null;
        task = Task.Factory.StartNew<int>(() => 
        {
            int hours;
            // . . .
            // Return statement specifies an integer result.
            return hours;
        }, CancellationToken.None, 
           TaskCreationOptions.None, 
           TaskScheduler.Current);
        try
        {
            return task.Result;
        }
        catch (AggregateException aggEx)
        {
            // Some handler method for the agg exception.
            aggEx.Handle(HandleException); 
        }
    }
    
