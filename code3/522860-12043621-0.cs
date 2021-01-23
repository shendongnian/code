    public class FriendList
    {
        // ...
        [DataMember]
        [InverseProperty("FriendLists")]
        public virtual User User { get; set; }
        // ...
    }
