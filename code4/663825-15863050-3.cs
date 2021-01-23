    [Table]
    public class UserAccount
    {
        [Column(IsPrimaryKey = true)]
        public string username;
        [Column]
        public string password;
        private EntitySet<UserRole> _userRole;
        [Association(Storage = "_userRole", OtherKey = "userName")]
        public EntitySet<UserRole> UserRoles
        {
            get { return this._userRole; }
            set { this._userRole.Assign(value); }
        }
    }
    [Table]
    public class Role
    {
        [Column(IsPrimaryKey = true)]
        public int roleId;
        [Column]
        public string roleName;
        private EntitySet<UserRole> _userRole;
        [Association(Storage = "_userRole", OtherKey = "roleId")]
        public EntitySet<UserRole> UserRoles
        {
            get { return this._userRole; }
            set { this._userRole.Assign(value); }
        }
    }
    [Table]
    public class UserRole
    {
        [Column(IsPrimaryKey = true)]
        public int roleId;
        [Column(IsPrimaryKey = true)]
        public string userName;
        private EntityRef<Role> _role;
        [Association(Storage = "_role", ThisKey = "userName")]
        public EntitySet<Role> Role
        {
            get { return this._role.Entity; }
            set { this._role.Assign(value); }
        }
        private EntityRef<UserAccount> _userAccount;
        [Association(Storage = "_userAccount", ThisKey = "userName")]
        public EntitySet<UserRole> UserAccount
        {
            get { return this._userAccount.Entity; }
            set { this._userAccount.Assign(value); }
        }
    }
