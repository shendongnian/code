    public static async Task DoStuff()
    {
        IDisposable disposable = null;
        try { }
        finally
        {
            var task = GenerateTask();
            var continuation = Task.WhenAny(task, Task.Delay(5000))
                .ContinueWith(t =>
                {
                    if (task.IsCompleted) //if false we timed out or it threw an exception
                    {
                        var result = task.Result;
                        //TODO use result
                    }
    
                    disposable.Dispose();
                });
        }
    }
