    namespace MyProject.Models
    {
        public class DatabaseContext: DbContext 
        {
             public DbSet<Projects> Projects { get; set; } 
             public DbSet<Sections> Sections{ get; set; }         
        }
    }
