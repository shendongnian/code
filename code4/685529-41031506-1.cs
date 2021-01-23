    public override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // global
        modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        // individual
        modelBuilder.Configurations.Add(new ProjectsDateMap());
    }
