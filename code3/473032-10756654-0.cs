    public class DataBaseContext : DbContext 
    {
         public DbSet<Projects> Projects{ get; set; }
         public DbSet<Sections> Sections { get; set; }
    }
