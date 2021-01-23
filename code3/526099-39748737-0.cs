    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var conventions = new List<PluralizingTableNameConvention>().ToArray();
        modelBuilder.Conventions.Remove(conventions);
    }
