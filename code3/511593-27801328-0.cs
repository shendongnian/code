    public partial class ExampleEntities : DbContext
        {
            public ExampleEntities()
                : base("name=ExampleEntities")
            {
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
            }
        
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }
