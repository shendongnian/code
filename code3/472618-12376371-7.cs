    public partial class BusinessUnit
    {
        public BusinessUnit()
        {
            this.ChlidBusinessUnits = new HashSet<BusinessUnit>();
            this.UserPermissions = new HashSet<UserPermissions>();
        }
    
        public int BusinessUnitID { get; set; }
        public string BusinessName { get; set; }
        public int ParentBusinessUnitID { get; set; }
    
        public virtual ICollection<BusinessUnit> ChlidBusinessUnits { get; set; }
        public virtual BusinessUnit ParentBusinessUnit { get; set; }
        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }
    public partial class User
    {
        public User()
        {
            this.UserPermissions = new HashSet<UserPermissions>();
        }
    
        public int UserID { get; set; }
        public string FirstName { get; set; }
    
        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }
    public partial class UserPermissions
    {
        public int UserPermissionsID { get; set; }
        public int BusinessUnitID { get; set; }
        public int UserID { get; set; }
    
        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual User User { get; set; }
    }
    public partial class BusinessModelContainer : DbContext
    {
        public BusinessModelContainer()
            : base("name=BusinessModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermissions> UserPermissions { get; set; }
    }
