    [Test, Timeout(2000)]
    public void DispatcherFail()
    {
        var wasRun = false;
        Action MyAction = () =>
            {
                Console.WriteLine("Running...");
                wasRun = true;
                Console.WriteLine("Run.");
            };
        Dispatcher.CurrentDispatcher.BeginInvoke(MyAction);
                
        Assert.IsTrue(wasRun);
    }
