    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")  // web.config
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    public class UserData
    {
        private static List<UserProfile> _userList;
        public static List<UserProfile> userList
        {
            get
            {
                if (_userList == null)
                {
                    UsersContext db = new UsersContext();
                    _userList = db.UserProfiles.SqlQuery("select * from dbo.UserProfile").ToList();
                }
                return _userList;
            }
            set
            {
                _userList = value;
            }
        }
    }
