    modelBuilder.Entity<SomeEntity>()
        .HasRequired(e => e.SomeOtherName)   // or .HasOptional(...)
        .WithMany()
        .HasForeignKey(e => e.VeryDifferentFKPropertyName);
    modelBuilder.Entity<SomeEntity>()
        .Property(e => e.VeryDifferentFKPropertyName)
        .HasColumnName("JustAnotherColumnName");
