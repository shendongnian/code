    // Log something going on.
    System.Threading.ThreadPool.QueueUserWorkItem((args) =>
    {
       System.Diagnostics.EventLog.WriteEntry("my source", "my logging message");
    });
