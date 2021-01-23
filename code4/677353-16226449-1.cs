    public partial class abook_dbEntities : DbContext
    {
        public abook_dbEntities()
            : base("name=abook_dbEntities")
        {
        }
    
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
