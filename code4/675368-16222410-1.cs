    public IObservable<Stuff> GetStuffObservable(string descriptor, ISchedulerLongRunning scheduler)
    {
        return Observable.Create<Stuff>(o=>
            {
                try{
                    var stuff = GetStuff(description);
                    o.OnNext(stuff);
                    o.OnCompleted
                }
                catch(Exception ex)
                {
                    o.OnError(ex);
                }
                return Disposable.Empty(); //If you want to be sync, you cant cancel!
            })
            .SubscribeOn(scheduler);
    }
