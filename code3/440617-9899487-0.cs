    static void Process()
    {
      Thread.Sleep(100); // Do CPU work.
    }
    static async Task Test()
    {
      await Task.Run(Process);
      await Task.Run(Process);
    }
