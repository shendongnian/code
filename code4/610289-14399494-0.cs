    public class Member
    {
        private ICollection<Subscription> _subscriptions;
        public Name() { _subscriptions = new HashSet<Subscription>(); }
        public Subscription Subscription
        {
            get { return _subscriptions.SingleOrDefault(); }
            set
            {
                _subscriptions.Clear(); // may want to check if it contains value first
                value.Member = this; // assuming bidirectional association
                _subscriptions.Add(value); // null check value first
            }
        }
    }
    mapping.HasMany<Subscription>(Reveal.Member<Member>("_subscriptions"))
        .KeyColumn("MemberId")
        .AsSet().Inverse().Cascade.AllDeleteOrphan();
