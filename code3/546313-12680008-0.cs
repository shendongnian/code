    public class MyContext : DbContext
    {
        //...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Student)
                .WithMany()
                .HasForeignKey(c => c.PersonId)
                .WillCascadeOnDelete(false);
        }
    }
