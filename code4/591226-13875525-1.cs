    public class MyClass
    {
      public Task EnQueue(workUnit item)
      {
        // Schedule the work on the thread pool. 
        // If you need limited concurrency here, there are schedulers to enable this.
        return Task.Run(() => DoLongRunningDBStuff(item));
      }
    } 
