    public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
    {
        //Add simple injector resolved types.
        filters.Add(container.GetInstance<UserAuthorisation>());
    }
