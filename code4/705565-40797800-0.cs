    public partial class MyDbContext : DbContext
    {
        // ... code ...
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Types<IFoo>().Configure(y => y.Property(e => e.Bar).IsRequired());
        }
    }
