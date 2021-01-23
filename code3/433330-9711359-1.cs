    public class EventVote
    {
    
        [Key, Column(Order = 0)]
        public int EventID { get; set; }
    
        [Key, Column(Order = 1)]
        public int UserID { get; set; }
    
        [Required]
        public DateTime VoteTime { get; set; }
    
        [Required]
        public bool Vote { get; set; }
    
    
        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
