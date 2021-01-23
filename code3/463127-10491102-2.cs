    //error checking
    var result = new TaskCompletionSource<object>();
    action().ContinueWith((t) => 
      {
        if (shouldRetry(t))
            action();
        else
        {
            if (t.IsFaulted)
                result.TrySetException(t.Exception);
            //and similar for Canceled and RunToCompletion
        }
      });
