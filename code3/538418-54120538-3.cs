        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Use our new DefaultValueConvention
            modelBuilder.Conventions.Add<EFExtensions.DefaultValueConvention>();
    
            // My personal favourites ;)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
