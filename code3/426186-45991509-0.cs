    static Task DoAsTask()
    {
        WriteOutput("1 - Starting");
        var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime, TaskCreationOptions.HideScheduler); //<-- HideScheduler do the magic
    
        TaskCompletionSource<int> tsc = new TaskCompletionSource<int>();
        t.ContinueWith(tsk => tsc.TrySetResult(tsk.Result)); //<-- Set the result to the created Task
    
        WriteOutput("2 - Task started");
    
        tsc.Task.ContinueWith(tsk => WriteOutput("3 - Task completed with result: " + tsk.Result)); //<-- Complete the Task
        return tsc.Task;
    }
