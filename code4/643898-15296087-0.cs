       public partial class AnonymousUID 
        {
            [Key]
            public int UID { get; set; }
            public string AnonymousUID1 { get; set; }
        }
        
        public class Model : DbContext
        {
            public DbSet<AnonymousUID> AnonymousUIDs { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AnonymousUID>()
                            .Property(a => a.AnonymousUID1)
                            .HasColumnName("AnonymousUID");
    
                modelBuilder.Entity<AnonymousUID>()
                    .ToTable("AnonymousUID");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var model = new Model();
              
                var a = new AnonymousUID();
    
                a.AnonymousUID1 = "hello world";
                model.AnonymousUIDs.Add(a);
                model.SaveChanges();
    
                var applications = model.AnonymousUIDs.ToList();
    
                Console.WriteLine(applications.Count);
                Console.ReadLine();
            }
        }
