    [Test]
    [TimeOut(5000)]
    public void CanFireAndForgetWithThreadingService()
    {
       var service = new ThreadingService();
       ManualResetEvent mre = new ManualRestEvent(bool); // I never remember what is the default...
       service.FireAndForget(() => mre.Set() /*will release the test asynchroneously*/);
       mre.WaitOne(); // blocks, will timeout if FireAndForget does not fire the action.
    }
