    public class User
    {
        //the following line with RoleId is not necessary, but it's good practice
        public int RoleId {get;set;}
        public virtual Role Role {get;set;}
    }
    
    public class Role
    {
        public virtual ICollection<User> Users {get;set;}
    }
