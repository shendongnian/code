    [Test, Timeout(2000)]
    public void Testing_with_Dispatcher_BeginInvoke()
    {
        var frame = new DispatcherFrame();  //1 - The Message loop
        var wasRun = false;
        Action MyAction = () =>
        {
            Console.WriteLine("Running...");
            wasRun = true;
            Console.WriteLine("Run.");
            frame.Continue = false;         //2 - Stop the message loop, else we hang forever
        };
        Dispatcher.CurrentDispatcher.BeginInvoke(MyAction);
                
        Dispatcher.PushFrame(frame);        //3 - Start the message loop
    
        Assert.IsTrue(wasRun);
    }
