    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParentClass>()
            .ToTable("Parent");
        modelBuilder.Entity<Foo>()
            .Map(m =>
                    {
                        m.Requires("IsActive").HasValue(1);
                        m.Requires("Type").HasValue("Foo");
                    });
        modelBuilder.Entity<Bar>()
            .Map(m =>
                    {
                        m.Requires("IsActive").HasValue(1);
                        m.Requires("Type").HasValue("Bar");
                    });
    }
