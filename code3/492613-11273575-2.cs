    public class Follow
    {
        [Key, Column(Order = 1), ForeignKey("Follower")]
        public Guid FollowerUserId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Following")]
        public Guid FollowUserId { get; set; }        
        
        public DateTime CreatedOnDate { get; set; }
        [InverseProperty("Followers")]  // refers to Followers in class User
        public virtual User Follower { get; set; }
        [InverseProperty("Following")]  // refers to Following in class User
        public virtual User Following { get; set; }
    }
