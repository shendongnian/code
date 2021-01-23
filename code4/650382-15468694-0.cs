    public class Friend
    {
    	[Key]
    	[Column(Order = 0)]
    	public int MyUserId { get; set; }
    	
    	[Key]
    	[Column(Order = 1)]
    	public int MyFriendId { get; set; }
    	
    	[ForeignKey("MyUserId")]
    	public virtual User MyUser { get; set; }
    
    	[ForeignKey("FriendId")]
    	public virtual User MyFriend { get; set; }
    
    	public bool IsAccepted { get; set; }
    }
