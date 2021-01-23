    public class Friend
    {
      public virtual List<FriendRelationship> UnorderedFriendList { get; set; }
    
      [NotMapped]
      public IEnumerable<Friend> Friends
      {
        get
        {
           return UnorderedFriendList.Select(p => p.Friend).OrderByDescending(p => p.OrderValue);
        }
      }
    }
    
