    TraceSource source = new TraceSource("foo");
    SourceSwitch onOff = new SourceSwitch("onOff", "Verbose");
    
    onOff.Level = SourceLevels.Verbose;
    
    ConsoleTraceListener console = new ConsoleTraceListener();
    
    source.Switch = onOff;
    bool alreadyDone = false;
    foreach (var listener in source.Listeners)
    {
        if (typeof(ConsoleTraceListener) == listener.GetType())
        {
            alreadyDone = true;
        }
    }
    if (!alreadyDone)
    {
        source.Listeners.Add(console);
    }
    
    source.TraceInformation("Hellow World! The trace is on!");
    
    List<WeakReference>  traceSources = 
               (List<WeakReference>)typeof(TraceSource)
                   .GetField("tracesources", BindingFlags.NonPublic | BindingFlags.Static)
                   .GetValue(source);
    foreach (WeakReference weakReference in traceSources)
    {
        TraceSource target = (TraceSource)weakReference.Target;
        source.TraceInformation(
              "Somebody, in code or config, registered this trace source " + target.Name);
        target.Listeners.Clear();
    }
    source.TraceInformation(
           "Can you still see this? (No you can't, I cleared all the listeners)");
