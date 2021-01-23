    public class Friend
        {
            public int FriendID { get; set; }
            public int RequestorID { get; set; }
            public int ResponderID { get; set; }
            public int FriendStatusID { get; set; }
            public DateTime User1RequestDate { get; set; }
            public DateTime User2ResponseDate { get; set; }
            public virtual FriendStatus FriendStatus { get; set; }
        
            [ForeignKey("RequestorID")] //fixed
            public virtual User Requestor { get; set; }
            [ForeignKey("ResponderID")]
            public virtual User Responder { get; set; }
        }
