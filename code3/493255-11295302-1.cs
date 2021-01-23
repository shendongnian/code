    // Subscribe
    eventAggregator.GetEvent<CollectionChangedMessage>().Subscribe(DoWork);
    
    // Broadcast
    eventAggregator.GetEvent<CollectionChangedMessage>().Publish();
