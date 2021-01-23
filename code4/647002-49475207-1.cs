    protected override void OnModelCreating( DbModelBuilder model_builder )
    {
        base.OnModelCreating( model_builder );
        model_builder.Entity<WeirdTable>().HasKey(
            t => new { t.Id1, t.Id2 }
        );
    }
