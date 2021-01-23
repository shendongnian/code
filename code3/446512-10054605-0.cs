    private Task _serviceTask;
    private bool _stop;
    
    protected override void OnStart(string[] args)
    {
        _serviceTask = Task.Factory.StartNew(SomeTask) 
    }
    // Rename the method from SomeTask to something that makes more sense
    private static void SomeTask()
    {
        // Move your code here
    }
