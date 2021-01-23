    public Task<bool> DoSomethingAsync()
    {
       var taskSource = new TaskCompletionSource<bool>();
    
       //Call some asynchronous Apple API
       NSSomeAppleApi.DoSomething(error =>
       {
          if (error != null)
             taskSource.SetException(new Exception(error.LocalizationDescription));
          else
             taskSource.SetResult(true);
       });
    
       return taskSource.Task;
    }
