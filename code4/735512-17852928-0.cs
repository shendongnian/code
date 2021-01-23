    public class User
    {
        public int Id { get; set; }
        public virtual ICollection<UserSession> UserSessions { get; set; }
    }
    
    public class Session
    {
        public int Id { get; set; }
        public virtual ICollection<UserSession> UserSessions { get; set; }
    }
    
    public class UserSession
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }
    
        [Key]
        [Column(Order = 2)]
        public int SessionId{ get; set; }
    
        public virtual User User { get; set; }
        public virtual Session Session { get; set; }
    }
