    static void Main()
    {
      MainAsync().Wait();
      // or, if you want to avoid exceptions being wrapped into AggregateException:
      //  MainAsync().GetAwaiter().GetResult();
    }
    static async Task MainAsync()
    {
      ...
    }
