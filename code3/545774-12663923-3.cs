      protected override void OnModelCreating( DbModelBuilder modelBuilder )
      {
         modelBuilder.Entity<Category>()
            .HasMany( c => c.ChildCategories )
            .WithOptional( ca => ca.RootCategory )
            .HasForeignKey( c => c.RootCategoryID );
      }
