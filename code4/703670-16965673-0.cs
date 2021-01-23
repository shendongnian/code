    class MyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Currencies)
                .WithMany()                 // Note the empty WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("CountryId");
                    x.MapRightKey("CurrencyId");
                    x.ToTable("CountryCurrencyMapping");
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
