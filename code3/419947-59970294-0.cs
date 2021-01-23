    private ReturnType RunSync()
    {
      var task = Task.Run(async () => await myMethodAsync(agency));
      if (task.IsFaulted && task.Exception != null)
      {
        throw task.Exception;
      }
    
      return task.Result;
    }
                
