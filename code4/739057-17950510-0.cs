    public class FriendDefinition
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Friend")]
        public int FriendUserId { get; set; }
        
        public virtual User User { get; set; }
        public virtual User Friend { get; set; }
    }
