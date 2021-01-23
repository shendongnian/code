    class ExecutionResult
    {
         public int ExecutionID { get; private set; }
         public Task<string> Result { get; private set; }
         // ... Add constructor, etc...
    }
    public ExecutionResult DoSomeWork()
    {
         var task = Task.Factory.StartNew( () =>
         {
              // Replace with real work, etc...
              return "Foo";
         });
         return new ExecutionResult(1, task); // Make the result from the int + Task<string>
    }
