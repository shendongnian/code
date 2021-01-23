    class Subscription
    {
       ICollection<SubscriptionDetail> SubscriptionDetails {get;set}
    }
    class SubscriptionDetail
    {
        Product Product {get; set;}
        int count {get; set;} // have a count vs. having multiple Product entries?
    }
