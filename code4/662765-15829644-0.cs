    public class EntitiesContext : DbContext
    {
        public DbSet<EntityType> Enities { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityType>().Property(e => e.ComputedProperty).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
