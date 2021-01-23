    public static void Main()
    {
        MainAsync().Wait();
    }
    
    public static async Task MainAsync()
    {
        try {
            var result = await dataStore.Save(data);
        } catch(ExceptionYouWantToCatch e) {
           // handle it
        }
    }
