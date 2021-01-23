    protected override void OnModelCreating(DbModelBuilder mb)
    {
        base.OnModelCreating(mb);
        mb.ToMyDatabaseNamingConvention(GetEntities());
    }
