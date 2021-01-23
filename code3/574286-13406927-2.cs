    public static Task WhenAll(IEnumerable<Task> tasks)
    {
        var tcs = new TaskCompletionSource<object>();
        List<Task> taskList = tasks.ToList();
    
        int remainingTasks = taskList.Count;
    
        foreach (Task t in taskList)
        {
            t.ContinueWith(_ =>
            {
                if (t.IsCanceled)
                {
                    tcs.TrySetCanceled();
                }
                else if (t.IsFaulted)
                {
                    tcs.TrySetException(t.Exception);
                }
                else //competed successfully
                {
                    if (Interlocked.Decrement(ref remainingTasks) == 0)
                        tcs.TrySetResult(null);
                }
            });
        }
    
        return tcs.Task;
    }
