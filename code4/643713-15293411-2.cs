    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new TopClassMap());
        modelBuilder.Configurations.Add(new ExampleAMap());
        modelBuilder.Configurations.Add(new ExampleBMap());
        modelBuilder.Configurations.Add(new ExampleCMap());
        // ....
    }
