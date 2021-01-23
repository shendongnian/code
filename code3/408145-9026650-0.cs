    public void Subscribe(SourceT sourceT, TypeT typeT, SubscriberT subT)
    {
        var typesAndSubs = SourceTypeSubs.GetOrAdd(sourceT,
            _ => new ConcurrentDictionary<TypeT, ConcurrentDictionary<SubscriberT, SubscriptionInfo>>());
        var subs = typesAndSubs.GetOrAdd(typeT,
            _ => new ConcurrentDictionary<SubscriberT, SubscriptionInfo>());
        subs.GetOrAdd(subT, _ => new SubscriptionInfo());
    }
