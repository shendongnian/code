    public class JobAndPopulationContext : DbContext
    {
      public DbSet<Destination> Destinations { get; set; }
      public DbSet<Origins> Origin { get; set; }  
    }
