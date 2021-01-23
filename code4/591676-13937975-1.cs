    [Test]
    public void Run_Action_as_IOb_on_scheduler_with_ObStart_dispose()
    {
        var scheduler = new TestScheduler();
        var flag = false;
        Action action = () => { flag = true; };
    
        var subscription = Observable.Start(action, scheduler).Subscribe();
                
    
        Assert.IsFalse(flag);
        subscription.Dispose();
        scheduler.AdvanceBy(1);
        Assert.IsFalse(flag);   //FAILS. Oh no! this is true!
    }
    [Test]
    public void Run_Action_as_IOb_on_scheduler_with_ObStart_no_subscribe()
    {
        var scheduler = new TestScheduler();
        var flag = false;
        Action action = () => { flag = true; };
    
        Observable.Start(action, scheduler);
        //Note the lack of subscribe?!
    
        Assert.IsFalse(flag);
        scheduler.AdvanceBy(1);
        Assert.IsFalse(flag);//FAILS. Oh no! this is true!
    }
