    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Foo>().Map(m => m.Requires("IsDeleted").HasValue(false));
       modelBuilder.Entity<Bar>().Map(m => m.Requires("IsDeleted").HasValue(false));
       
       //It's more complicated if you have derived entities. 
       //Here 'Block' derives from 'Property'
       modelBuilder.Entity<Property>()
                .Map<Property>(m =>
                {
                    m.Requires("Discriminator").HasValue("Property");
                    m.Requires("IsDeleted").HasValue(false);
                })
                .Map<Block>(m =>
                {
                    m.Requires("Discriminator").HasValue("Block");
                    m.Requires("IsDeleted").HasValue(false);
                });
    }
