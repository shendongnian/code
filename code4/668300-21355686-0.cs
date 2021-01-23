    public class MyTrust
        {
            public MyTrust()
            {
                MyLocations = new List<MyLocation>();
            }
            public int MyTrustID { get; set; }
            public string MyTrustName { get; set; }
            public virtual ICollection<MyLocation> MyLocations { get; set; }
        }
        public class MyLocation
        {
          
            public int MyLocationID { get; set; }
            public string MyLocationName { get; set; }
            public virtual MyTrust MyTrust { get; set; }
    }
    
    public class TaskDbContext : DbContext
        {
            public DbSet<MyTrust> MyTrusts { get; set; }
            public DbSet<MyLocation> MyLocations { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MyTrust>().HasMany(t => t.MyLocations).WithRequired();
            }
        }
