    public class MyDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         modelBuilder.Entity<UserProfile>()
                        .HasRequired(u => u.Person)
                        .WithOptional(p => p.UserProfile)
                        .Map(m => m.MapKey("PersonId"));
        }
    }
