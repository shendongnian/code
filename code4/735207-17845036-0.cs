    Public Class Person {
        public int PersonId {get;set;}
        public virtual IEnumerable<SubscriptionInfo> SubscriptionInfos {get;set;}
    }
    Public Class Subscription {
        public int SubscriptionId {get;set;}
        public virtual IEnumberable<SubscriptionInfo> SubscriptionInfos {get;set}
    }
    Public Class SubscriptionInfo {
        public int PersonId {get;set;}
        public int SubscriptionId {get;set;}
        public DateTime SubscribedOn {get;set;}
        [RelatedTo(ForeignKey="PersonId")]
        Public virtual Person Person {get;set;}
        [RelatedTo(ForeignKey="SubscriptionId")]
        Public virtual Subscription Subscription {get;set;}
    }
    var db = new PeopleSubscribedEntities();
    var subscription = db.Subscriptions.Find(1);
    var people = subscription.SubscriptionInfos.Select(si => si.Person 
                                                      && si => si.SubscribedOn > someDate);
