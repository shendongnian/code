    modelBuilder.Entity<SomeEntity>()
        .HasOptional(x => x.DefaultItem)
        .WithOptionalPrincipal() // x => x.DefaultForEntity)
        .WillCascadeOnDelete(false);
    ...
    // public SomeEntity DefaultForEntity { get; set; } // optional
