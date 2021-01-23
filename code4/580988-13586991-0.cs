    Trace.Listeners.Clear();
            TextWriterTraceListener twtl = new TextWriterTraceListener(Path.Combine(Environment.CurrentDirectory, "logfile.txt"));
            twtl.Name = "TextLogger";
            twtl.TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime | TraceOptions.Callstack;
            ConsoleTraceListener ctl = new ConsoleTraceListener(false);
            ctl.TraceOutputOptions = TraceOptions.DateTime;
            Trace.Listeners.Add(twtl);
            Trace.Listeners.Add(ctl);
            Trace.AutoFlush = true;
