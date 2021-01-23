    ServiceHost host = new ServiceHost(typeof(MyService));
    
    string msg = "Service Behaviors:" + Environment.NewLine;
    foreach (IServiceBehavior behavior in host.Description.Behaviors)
    {
        msg += behavior.ToString() + Environment.NewLine;
    
        if (behavior is ServiceThrottlingBehavior)
        {
            ServiceThrottlingBehavior serviceThrottlingBehavior = (ServiceThrottlingBehavior)behavior;
            msg += "     maxConcurrentSessions =   " + serviceThrottlingBehavior.MaxConcurrentSessions.ToString() + Environment.NewLine;
        }
    }
    EventLog.WriteEntry("My Log Source", msg,  EventLogEntryType.Information);
