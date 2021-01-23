    public class User
    {
        public int UserId { get; set; }
        //...
        public ICollection<UserSystemRole> UserSystemRoles { get; set; }
    }
    public class System
    {
        public int SystemId { get; set; }
        //...
        public ICollection<UserSystemRole> UserSystemRoles { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        //...
        public ICollection<UserSystemRole> UserSystemRoles { get; set; }
    }
