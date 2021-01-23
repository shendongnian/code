    [Test]
    public void Run_Action_as_IOb_on_scheduler_with_ObCreate()
    {
        var scheduler = new TestScheduler();
        var flag = false;
        Action action = () => { flag = true; };
    
        var subscription = Observable.Create<Unit>(observer =>
            {
                try
                {
                    action();
                    observer.OnNext(Unit.Default);
                    observer.OnCompleted();
                }
                catch (Exception ex)
                {
                    observer.OnError(ex);
                }
                return Disposable.Empty;
            })
            .SubscribeOn(scheduler)
            .Subscribe();   //Without subscribe, the action wont run.
    
        Assert.IsFalse(flag);
        scheduler.AdvanceBy(1);
        Assert.IsTrue(flag);
        subscription.Dispose(); //Not required as the sequence will have completed and then auto-detached.
    }
    
    [Test]
    public void Run_Action_as_IOb_on_scheduler_with_ObCreate_dispose()
    {
        var scheduler = new TestScheduler();
        var flag = false;
        Action action = () => { flag = true; };
    
        var subscription = Observable.Create<Unit>(observer =>
        {
            try
            {
                action();
                observer.OnNext(Unit.Default);
                observer.OnCompleted();
            }
            catch (Exception ex)
            {
                observer.OnError(ex);
            }
            return Disposable.Empty;
        })
            .SubscribeOn(scheduler)
            .Subscribe();   //Without subscribe, the action wont run.
    
        Assert.IsFalse(flag);
        subscription.Dispose();
        scheduler.AdvanceBy(1);
        Assert.IsFalse(flag);   //Subscription was disposed before the scheduler was able to run, so the action did not run.
    }
