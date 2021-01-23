    public class StatsContext : DbContext
    {
        
        public DbSet<MapRatingsVSH> MapRatingsVSH { get; set; }
    
        public DbSet<MapRatingsJump> MapRatingsJump { get; set; }
    
    }
