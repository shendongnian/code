    public class User 
    {
        public int UserID { set; get; }
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }      
    }
    public class Role 
    {      
        public int RoleID { set;get;}
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
    public class UserRole 
    {
        public int UserRoleID { set; get; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
    public class AnotherEntity
    {
        public int ID { set; get; }
        public int UserRoleID { set; get; }     
    }
