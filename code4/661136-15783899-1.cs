        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<E1Type>()
                .HasMany(e1 => e1.Collection)
                .WithMany(e2 => e2.Collection)
                .Map(config => config.ToTable("MyTable"));
        }
