    public Task<TBase> Run()
    {
      var tcs = new TaskCompletionSource<TBase>();
      MethodThatReturnsDerivedTask().ContinueWith(t =>
      {
        if (t.IsFaulted)
          tcs.TrySetException(t.Exception.InnerExceptions);
        else if (t.IsCanceled)
          tcs.TrySetCanceled();
        else
          tcs.TrySetResult(t.Result);
      }, TaskContinuationOptions.ExecuteSynchronously);
      return tcs.Task;
    }
