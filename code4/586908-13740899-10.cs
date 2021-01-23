    static class TaskEx
    {
        public static Task TransformWith(this Task future, Action<Task> continuation)
        {
            var tcs = new TaskCompletionSource<object>();
            future
                .ContinueWith(t =>
                {
                    if (t.IsCanceled)
                    {
                        tcs.SetCanceled();
                    }
                    else if (t.IsFaulted)
                    {
                        tcs.SetException(t.Exception.InnerExceptions);
                    }
                    else
                    {
                        try
                        {
                            continuation(future);
                            tcs.SetResult(null);
                        }
                        catch (Exception e)
                        {
                            tcs.SetException(e);
                        }
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
    
            return tcs.Task;
        }    
    }
