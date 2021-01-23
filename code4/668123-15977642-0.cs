    [Test]
    public void HandleRequestForATest()
    {
        // setup the data in the IFC here
    
        var resetEvent = new ManualResetEvent(false);
        InfoA info = null;
        var observer = NSNotificationCenter.DefaultCenter.AddObserver(Notifications.ResponseA, delegate(NSNotification ntf)
        {
            info = ntf.Object as InfoA;
            resetEvent.Set();
        }
    
        NSNotificationCenter.DefaultCenter.PostNotificationName(Notifications.RequestA, null);        
        Assert.IsTrue(resetEvent.WaitOne(250), "Reset event timed out!");
        Assert.IsNotNull(info, "Info is null!");
        // some other asserts to check the data within info
        //Make sure you do this! I'd put in try-finally block
        NSNotificationCenter.DefaultCenter.RemoveObserver(observer);
    }
