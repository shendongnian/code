    Trace.Listeners.Clear();
                    
    if (options.Verbose)
    {
        var ctl = new ConsoleTraceListener(false) { TraceOutputOptions = TraceOptions.DateTime };
        Trace.Listeners.Add(ctl);
    }
    if (options.Log)
    {
        var logFileFs = new FileStream("my.log", FileMode.Append);
        var twtl = new TextWriterTraceListener(logFileFs)
        { TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime };
        Trace.Listeners.Add(twtl);
    }
    Trace.AutoFlush = true;
    
    Trace.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + "   My App Started");
