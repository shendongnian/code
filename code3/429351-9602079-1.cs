    string cs = "CustomSource";
    EventLog elog = new EventLog();
    
    if (!EventLog.SourceExists(cs))
        EventLog.CreateEventSource(cs, cs);
    int eventID = 8;
    elog.Source = cs;
    elog.EnableRaisingEvents = true;
    elog.WriteEntry(message, System.Diagnostics.EventLogEntryType.Error,
                        eventID);
