    using System.Data.Entity;
    public partial class UniversityContext : DbContext 
    { 
        public DbSet<University> Universities { get; set; } 
    }
