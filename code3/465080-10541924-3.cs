    public static void Main()
    {
      var sleeper = new Sleeper();
    
      Task.Factory.StartNew(
        () =>
        {
          while (true)
          {
            sleeper.Sleep(TimeSpan.FromMinutes(1);
          }
        });
    
      while (true)
      {
        Console.WriteLine("Press ENTER to get time remaining...");
        Console.ReadLine();
        TimeSpan remaining = sleeper.GetRemaining();
        Console.WriteLine("Remaining = " + remaining.ToString());
      }
    }
