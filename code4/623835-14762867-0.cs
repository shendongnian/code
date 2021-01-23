    public void Start(int seconds)
    {
        // Every tick, generate a "changeset"
        var changeCentral =
            from tick in Observable.Interval(TimeSpan.FromSeconds(seconds))
            let results = this.checker.Refresh(this.knowEntities)
            select new EntityChangeSet(results);
        
        // Publish means one subscription for all "connecting" subscribers
        // RefCount means so long as one subscriber is subscribed, the subscription remains alive
        var connector = changeCentral.Publish().RefCount();
        Changes = connector;
    }
