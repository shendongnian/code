    public static void EventLogWrite(string Source, string Message, short categoryID, int eventID, EventLogEntryType entryType)
    {
    #if !DEBUG
      if (!EventLog.SourceExists(Source))
        EventLog.CreateEventSource(Source.RefineText(), "My Log Name");
      EventLog.WriteEntry(Source.RefineText(), Message.TrimText(3000), entryType, eventID, categoryID);
    #endif
    }
