    TraceSource ts = new TraceSource("TraceTest");
    ts.TraceEvent(TraceEventType.Information, 123, "event info");
    ts.TraceEvent(TraceEventType.Error, 123, "event error");
    ts.TraceEvent(TraceEventType.Warning, 123, "event warning");
    ts.TraceInformation("any text");
    ts.Flush();
    ts.Close();
