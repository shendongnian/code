    ITracingService trace 
      = (ITracingService)Service.GetService(typeof(ITracingService));
    trace.Trace("Commencing.");
    ...
    throw new Exception("Intentional!");
