    public MyService()
    {
        var bootsrapper = new MyServiceBoostrapper();
        bootsrapper.Run();
        // This is an extension method. You'll need to add
        // System.ComponentModel.Composition to your using statements.
        bootstrapper.MyServiceContainer.SatisfyImportsOnce(this);
        // At this stage, "db" should not be null.
    }
