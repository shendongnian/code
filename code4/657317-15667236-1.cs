    public partial class Role
    {
        public RoleView()
        {
            this.Users = new HashSet<RoleUser>();
        }
        public ICollection<RoleUser> Users { get; set; }
    }
