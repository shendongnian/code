    public class MyTesterContext : DbContext
    {        
        public MyTesterContext () : base("name=MyTesterContext ")
        {
        }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().
              HasMany(t => t.Itinerary).
              WithMany(l => l.Trips).
              Map(
               m =>
               {
                   m.MapLeftKey("TripID");
                   m.MapRightKey("LocationID");
                   m.ToTable("TripLocations");
               });
        }
    }
