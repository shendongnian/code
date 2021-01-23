    if (!EventLog.Exists(sLogName))
         return; // or show error message
    // build xml
    EventLog log = new EventLog(sLogName); // specify log name
    var xml = new XDocument(
        new XElement(sLogName,
            from EventLogEntry entry in log.Entries
            orderby entry.TimeGenerated descending
            select new XElement("Log",
              new XElement("Message", entry.Message),
              new XElement("TimeGenerated", entry.TimeGenerated),
              new XElement("Source", entry.Source),
              new XElement("EntryType", entry.EntryType.ToString())
            )
        ));  
  
