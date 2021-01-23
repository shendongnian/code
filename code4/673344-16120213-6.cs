    public class User
    {
        public int UserId { get; set; }
        //...
        public ICollection<UserSystemRole> UserSystemRoles { get; set; }
        public IDictionary<System, IEnumerable<Role>> SystemRoles
        {
            get
            {
                return UserSystemRoles
                    .GroupBy(usr => usr.System)
                    .ToDictionary(g => g.Key, g => g.Select(usr => usr.Role));
            }
        }
    }
