    class ExecutionResult
    {
         public int ExecutionID { get; set; }
         public string Result { get; set; }
         // ...
    }
    public Task<ExecutionResult> DoSomeWork()
    {
         return Task.Factory.StartNew( () =>
         {
              // Replace with real work, etc...
              return new ExecutionResult { ExecutionID = 0, Result = "Foo" };
         });
    }
