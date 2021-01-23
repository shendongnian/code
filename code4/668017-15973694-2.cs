    Task task1 = Task.Factory.StartNew(() => this.OriginalFileProcessor.StartPolling()).ContinueWith( t =>
    {
         var aggException = t.Exception.Flatten();
         foreach(var ex in aggException.InnerExceptions)
             this.Log.Error("Failed running the task", ex);
    }, 
    TaskContinuationOptions.OnlyOnFaulted);
