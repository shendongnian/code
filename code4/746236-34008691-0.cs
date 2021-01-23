        public EventsEntities()
            : base("name=EventsEntities")
        {
            Configuration.ProxyCreationEnabled = false;
        }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }`
