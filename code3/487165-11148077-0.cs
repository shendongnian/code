    public class MyDbContext : DbContext {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Minutes>().Property(x => x.Value);
            modelBuilder.Entity<MyEntity>().Property(x => x.MyMinutes.Value).HasColumnName("MYMINUTES");
        }
    }
