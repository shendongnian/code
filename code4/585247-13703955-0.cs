    static void Main(string[] args)
    {
      var t = new CancellationTokenSource();
      var task = Monitor(t.Token);
      while (true)
      {
        if (Console.ReadLine() == "cancel")
        {
          t.Cancel();
          try 
          {
            task.Wait();
          }
          catch(AggregateException)
          {
            Console.WriteLine("Exception via task.Wait()");
          }
          Console.WriteLine("Cancelled");
        }
      }
    }
    static async Task Monitor(CancellationToken token)
