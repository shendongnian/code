    [DataMember]
    public virtual Guid UserId { get; set; }
    [DataMember]
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    [DataMember]
    public virtual Guid FriendUserId { get; set; }
    [DataMember]
    [ForeignKey("FriendUserId")]
    public virtual User FriendUser { get; set; }
