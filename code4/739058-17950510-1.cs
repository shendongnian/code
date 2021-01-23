    public class User
    {
        public int UserId { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String Email { get; set; }
        public String InterestIn { get; set; }
    
        public virtual ICollection<FriendDefinition> Friends { get; set; }
    }
