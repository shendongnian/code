    public class EFDbContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Attibute> Attributes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
