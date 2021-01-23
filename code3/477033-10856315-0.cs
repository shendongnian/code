    public class Role 
    { 
        public static List<Role> AllRoles = new List<Role>() 
        { 
            Administrators, 
            PowerUsers, 
            Limited 
        }; 
 
        public static Role Administrators = new Role() { Name = "Bob" }; 
        public static Role PowerUsers = new Role() { Name = "Jimbo" }; 
        public static Role Limited = new Role() { Name = "Jack" }; 
 
        public string Name { get; set; } 
    } 
