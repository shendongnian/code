    public static Task<TResult> ToTask<TResult>(this IEnumerable<Task> tasks, TaskScheduler taskScheduler)
    {
        var taskEnumerator = tasks.GetEnumerator();
        var completionSource = new TaskCompletionSource<TResult>();
     
        // Clean up the enumerator when the task completes.
        completionSource.Task.ContinueWith(t => taskEnumerator.Dispose(), taskScheduler);
     
        ToTaskDoOneStep(taskEnumerator, taskScheduler, completionSource, null);
        return completionSource.Task;
    }
    
    public static Task<TResult> ToTask<TResult>(this IEnumerable<Task> tasks)
    {
        var taskScheduler = SynchronizationContext.Current == null
           ? TaskScheduler.Default 
           : TaskScheduler.FromCurrentSynchronizationContext();
        
        return ToTask<TResult>(tasks, taskScheduler);
    }
