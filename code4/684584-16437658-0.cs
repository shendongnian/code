    public static void IgnoreFailure(this Task task) {
        if (task.IsCompleted) { // observe now
            // this is just an opaque method to ensure it gets evaluated
            if (task.IsFaulted) GC.KeepAlive(task.Exception);
        }
        else { // observe in the future
            task.ContinueWith(t => {
                if (t.IsFaulted) GC.KeepAlive(t.Exception);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
