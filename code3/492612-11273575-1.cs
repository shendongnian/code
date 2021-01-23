    public class Follow
    {
        [Key, Column(Order = 1), ForeignKey("Follower")]
        public Guid FollowerUserId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Following")]
        public Guid FollowUserId { get; set; }        
        
        public DateTime CreatedOnDate { get; set; }
        public virtual User Follower { get; set; }
        public virtual User Following { get; set; }
    }
