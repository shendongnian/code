    var task = DoWorkAsync().ContinueWith(t=>{
     if(t.Exception.InnerExceptions[0].GetType() == typeof(TimeoutException))
     {
         throw new BackoffException(t.Exception.InnerExceptions[0]);
     }
    }, TaskContinuationOptions.OnlyOnFaulted);
