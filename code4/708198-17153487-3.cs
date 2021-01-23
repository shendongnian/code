    var incall = new ManualResetEvent(false);
    var unblock = new ManualResetEvent(false);
    var context = new CustomSynchronizationContext();
    var t = Task.Run(() =>context.Post(state =>
    {
        incall.Set();
        unblock.WaitOne(5000);
    }, null));
    Assert.IsTrue(incall.WaitOne(1000));
    Assert.IsTrue(t.Wait(1000)); //This will timeout if unblock is blocking completion of the task
    unblock.Set();
