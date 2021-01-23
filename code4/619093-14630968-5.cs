    public static Task Then(this Task first, Func<Task> next)
    {
      var tcs = new TaskCompletionSource<object>();
      first.ContinueWith(_ =>
      {
        if (first.IsFaulted) tcs.TrySetException(first.Exception.InnerExceptions);
        else if (first.IsCanceled) tcs.TrySetCanceled();
        else
        {
          try
          {
            next().ContinueWith(__ =>
            {
              if (t.IsFaulted) tcs.TrySetException(t.Exception.InnerExceptions);
              else if (t.IsCanceled) tcs.TrySetCanceled();
              else tcs.TrySetResult(null);
            }, TaskContinuationOptions.ExecuteSynchronously);
          }
          catch (Exception exc) { tcs.TrySetException(exc); }
        }
      }, TaskContinuationOptions.ExecuteSynchronously);
      return tcs.Task; 
    }
