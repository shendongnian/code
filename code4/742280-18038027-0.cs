    [BeforeFeature]
    public static void BeforeFeature()
    {
        MappingConfig.RegisterMappings();
        Database.SetInitializer(new TestDatabaseInitializer());
    }
