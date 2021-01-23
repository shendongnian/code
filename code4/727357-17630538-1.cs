    static void Main()
    {
      AsyncContext.Run(() => MainAsync());
    }
    static async Task MainAsync()
    {
      ...
    }
