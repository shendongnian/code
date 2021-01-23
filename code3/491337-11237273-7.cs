    public class MyContext : DbContext 
    {
       ...
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                    .Map(a => a.ToTable("DB_USERS"))
                    .Property(a => a.Email).HasColumnName("MAIL");
                base.OnModelCreating(modelBuilder);
            }
    }
