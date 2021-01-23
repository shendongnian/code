    public static void Main()
    {
        MainAsync().Wait();
    }
    
    public static async Task MainAsync()
    {
        var datastore = …;
        await datastore.SaveAsync();
    }
