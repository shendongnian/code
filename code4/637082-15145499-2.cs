    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public int UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile UserProfile { get; set; }
    }
