    public class SomeEntities : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore ColumnTypeCasing convention
            modelBuilder.Conventions.Remove<ColumnTypeCasingConvention>();
        }
    }
