    private Task<int> DoWorkAsync()
    {
        //create a task completion source
        //the type of the result value must be the same
        //as the type in the returning Task
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        Task.Run(() =>
        {
            int result = 1 + 2;
            //set the result to TaskCompletionSource
            tcs.SetResult(result);
        });
        //return the Task
        return tcs.Task;
    }
    private async void DoWork()
    {
        int result = await DoWorkAsync();
    }
