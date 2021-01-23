    public class UserSystemRole
    {
        public int UserId { get; set; }
        public int SystemId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public System System { get; set; }
        public Role Role { get; set; }
    }
