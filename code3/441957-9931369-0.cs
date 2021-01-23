    public class Location
    {
        public string Department { get; set; }
        public string Queue { get; set; }
    }
    public class MyEntity
    {
        public int Id { get; set; }
        public Location Original { get; set; }
        public Location Current { get; set; }
    }
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Location>();
            modelBuilder.Entity<MyEntity>().Property(x => x.Current.Queue).HasColumnName("myCustomColumnName");
        }
    }
