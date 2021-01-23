    using D = System.Diagnostics;
    
    ...
    
    protected void Application_Start()
    {
       if (D.Trace.Listeners["MyTraceListener"] == null)
       {
          D.Trace.Listeners.Add(new MyTraceListener("") { Name = "MyTraceListener" });
       }
    
       ...
    }
