    public class Foo    
    {
        public int Id { get; set; }
        public DateTime IAmSoSmall { get; set; }    // wants to be smalldatetime in SQL
    }
    public class MyContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var foo = modelBuilder.Entity<Foo>();
            foo.Property(f => f.IAmSoSmall).HasColumnType("smalldatetime");
            base.OnModelCreating(modelBuilder);
        }
    }
