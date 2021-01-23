    private static void Main(string[] args)
    {
      MainAsync().Wait();
    }
    private static async Task MainAsync()
    {
      var rnd = new Random();
      var randomTask = GetRandomNumber(rnd);
      System.Console.Write("Loading .");
      while (await Task.WhenAny(randomTask, Task.Delay(500)) != randomTask)
      {
        System.Console.Write(".");
      }
      System.Console.WriteLine();
    }
    private static Task GetRandomNumber(Random rnd)
    {
      return Task.Run(() =>
      {
        while (rnd.Next() != 0)
        {
        }
      });
    }
