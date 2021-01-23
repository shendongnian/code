    public Task RunAsync(Action action)
    {
        TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
    
        if (this.synchronizationContext == SynchronizationContext.Current)
        {
            try
            {
                action();
                taskCompletionSource.SetResult(null);
            }
            catch (Exception exception)
            {
                taskCompletionSource.SetException(exception);
            }
        }
        else
        {
            // Run the action asyncronously. The Send method can be used to run syncronously.
            this.synchronizationContext.Post(
                (obj) => 
                {
                    try
                    {
                        action();
                        taskCompletionSource.SetResult(null);
                    }
                    catch (Exception exception)
                    {
                        taskCompletionSource.SetException(exception);
                    }
                }, 
                null);
        }
        
        return taskCompletionSource.Task;
    }
