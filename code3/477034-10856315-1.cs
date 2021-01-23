    public class Role
    {
        public static Role Administrators;
        public static Role PowerUsers;
        public static Role Limited;
        public static List<Role> AllRoles;
        static Role()
        {
            Administrators = new Role() {Name = "Bob"};
            PowerUsers = new Role() {Name = "Jimbo"};
            Limited = new Role() {Name = "Jack"};
            AllRoles = new List<Role>()
                {
                    Administrators,
                    PowerUsers,
                    Limited
                };
        }
        public string Name { get; set; }
    }
