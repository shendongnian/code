    public DbSet<YourEntity> YourEntities { get; set; }
    ...
    // this is called when the db gets created and does the configuration for you => maybe not needed in your case
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        ConfigurationRegistrar configurationRegistrar = modelBuilder.Configurations;
        new GeneralEntitiesConfiguration(configurationRegistrar);
    }
