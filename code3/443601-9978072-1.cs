    public class userGroups
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
    
    public class Users
    {   
        public int ID { get; set; }        
        public string Name { get; set; }
        public virtual userGroups UserGroup { get; set; }
    }
