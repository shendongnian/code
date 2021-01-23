    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        // Other User properties...
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
    
    public class Group
    {
        public int Id { get; set; }
        // Other Group properties...
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
    public class UserGroup
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
