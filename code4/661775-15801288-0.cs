    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
    
        public SerialNumber Serial { get; set; }
    
        ...
    }
    
    public class SerialNumber
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
    
        public UserProfile User { get; set; }
    
        ...
    }
