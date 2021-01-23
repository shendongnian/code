    public static Task FailFastOnException(this Task task) 
    { 
        task.ContinueWith(c => Environment.FailFast(“Task faulted”, c.Exception), 
            TaskContinuationOptions.OnlyOnFaulted | 
            TaskContinuationOptions.ExecuteSynchronously | 
            TaskContinuationOptions.DetachedFromParent); 
        return task; 
    }
