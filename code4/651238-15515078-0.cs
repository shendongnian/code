    public class User
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        [InverseProperty("Users")]
        public virtual Group group { get; set; }
    }
    public class Group
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public User Owner { get; set; }
        public virtual ICollection<User> Users { get; set; } 
    }
