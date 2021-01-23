    private ICollection<Subscription> _subscriptions;
    public virtual ICollection<Subscription> Subscriptions
    {
        get 
        {   
            if (_subscriptions == null) _subscriptions = 
                new Collection<Subscription>();
            return _subscriptions; 
        }
        set { _subscriptions = value; }
    }
