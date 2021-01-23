        public class Dbo : DbContext
        {
            public DbSet<class1> Classs { get; set; }
            public Dbo()
            {
                Database.SetInitializer<Dbo>(null);
            }
        }
