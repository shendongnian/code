    [Test]
    public void Run_Action_as_IOb_on_scheduler_with_ObStart()
    {
        var scheduler = new TestScheduler();
        var flag = false;
        Action action = () => { flag = true; };
    
        var subscription = Observable.Start(action, scheduler)
                                        .Subscribe();
    
        Assert.IsFalse(flag);
        scheduler.AdvanceBy(1);
        Assert.IsTrue(flag);
        subscription.Dispose(); //Not required as the sequence will have completed and then auto-detached.
    }
