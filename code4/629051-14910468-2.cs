    void dt_Tick(object sender, EventArgs e)
    {
        Trace.TraceInformation("Tick: {0}", Thread.CurrentThread.ManagedThreadId);
        ...
    }
 
    void storyBoardTest_Completed(object sender, EventArgs e)
    {
        Trace.TraceInformation("Completed: {0}", Thread.CurrentThread.ManagedThreadId);
        ...
    } 
