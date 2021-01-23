    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasRequired(u => u.MainCityDetail)
                .WithMany()
                .HasForeignKey(u => u.MainCityId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Cities)
                .WithRequired(d => d.User)
                .HasForeignKey(d => d.UserId);
        }
    }
