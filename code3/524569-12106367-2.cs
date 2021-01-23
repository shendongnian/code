    public static void RegisterGlobalFilters(
        GlobalFilterCollection filters, Container container)
    {
        filters.Add(new HandleErrorAttribute());
        // Add global filters via DI.
        var singletonFilter = 
            container.GetInstance<UserAuthorisation>();
        filters.Add(singletonFilter);
     }
