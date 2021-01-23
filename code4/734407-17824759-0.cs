    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelbuilder.ComplexType<CommunicationDetails>();
            modelbuilder.ComplexType<GeneralDetails>();
            modelbuilder.ComplexType<Address>();
            modelbuilder.Entity<User>().ToTable("Users");
        }
    }
