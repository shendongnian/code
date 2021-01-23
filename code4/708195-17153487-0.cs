    var incall = new ManualResetEvent(false);
    var unblock = new ManualResetEvent(false);
    var context = new CustomSynchronizationContext();
    var t = Task.Run(() => context.Send(state =>
    {
        incall.Set();
        unblock.WaitOne(5000);
    }, null));
    Assert.IsTrue(incall.WaitOne(1000));
    Assert.IsTrue(t.Status == TaskStatus.Running);
    unblock.Set();
    Assert.IsTrue(t.Wait(1000));
