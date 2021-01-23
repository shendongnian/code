    var obs = new[] {1,2,3}.ToObservable()
        .Multicast(new Subject<int>())
    
    // TODO: Subscribe as many people as you want
    obs.Connect();  // Everyone subscribed gets 1,2,3,Completed now
    obs.Subscribe(...);  // This guy gets no results
