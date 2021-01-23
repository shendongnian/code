    private void Foo()
    {
      var childThreads = new List<Task>();
      for (int i = 0; i < 15; i++)
      {
        var task = new Task(Method);
        task.Start();
        childThreads.Add(task);
      }
    
      var completionTask = new Task(() => 
      { 
        Task.WaitAll(childThreads.ToArray());
      }).ContinueWith(t => CompletionWork());
    
    }
    
    private void Method()
    {
    }
    
    private void CompletionWork()
    {
    }
