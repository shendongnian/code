        public class MyDbContext : DbContext
        {
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                Database.SetInitializer<MyDbContext>(null);
            }
        }
