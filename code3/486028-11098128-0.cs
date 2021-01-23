    public class UserToRequestSubscription
    {
        public virtual int Id{get;set;}
        public vitual User User{get;set;} // you'd probably also change this, too
        public virtual RequestForHelp Request { get; set; } // changed
        public virtual bool AcceptedByRequester { get; set; }
    }
    public UserToRequestSubscriptionMapping()
    {
        Id(x => x.Id);
        Map(x => x.CreatedDate);
        Map(x => x.AcceptedByRequester);
        Map(x => x.IsActive);
        Map(x => x.DeactivatedDate);
        References(x => x.Request).Column("RequestId");
        References(x => x.User).Column("UserId");
        Table("TheTable");
    }
