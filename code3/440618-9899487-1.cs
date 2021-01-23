    static void Process()
    {
      Thread.Sleep(100); // Do CPU work.
    }
    static async Task Test()
    {
      // Start two background operations.
      Task task1 = Task.Run(Process);
      Task task2 = Task.Run(Process);
      // Wait for them both to complete.
      await Task.WhenAll(task1, task2);
    }
