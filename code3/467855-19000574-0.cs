    // Store indices of last accessed EventLogEntries in Dictionary {logType, lastIndex}
    private static readonly Dictionary<string, int> _lastIndices = new Dictionary<string, int>();
    public static void FindAllLog(string machineName)
    {
        //EventLog log = new EventLog("", "");
        //log.
        EventLog[] remoteEventLogs;
        // Gets logs on the local computer, gives remote computer name to get the logs on the remote computer.
        remoteEventLogs = EventLog.GetEventLogs(machineName);
        Console.WriteLine("Number of logs on computer: " + remoteEventLogs.Length);
   
        for (int i = 0; i < remoteEventLogs.Length; i++)
        {
            Console.WriteLine("Log : " + remoteEventLogs[i].Log);
            ReadEventLog(machineName, remoteEventLogs[i].Log, DateTime.Now.AddDays(-30));
            //ReadAppEventLog(machineName, remoteEventLogs[i].Log);                
        }
    }
    
    public static void ReadEventLog(string machine, string logType, DateTime fromDate)
    {
        int lastIndex;
        EventLog ev = new EventLog(logType, machine);
        IList<EventLogEntry> entries = new List<EventLogEntry>();
    
        if (_lastIndices.ContainsKey(logType))
            lastIndex = _lastIndices[logType];
        else {
            lastIndex = 0;
            _lastIndices.Add(logType, 0);
        }
    	
        // Try to avoid LINQ because it uses Enumerator and Loops EVERYTIME trough all items.
        // Start Looping from top of the list and break if Entry has Index less than lastIndex or
        // if Entry has TimeWritten less than fromDate
        for (var i = ev.Entries.Count - 1; ev.Entries[i].Index > lastIndex && ev.Entries[i].TimeWritten > fromDate; i--)
            entries.Add(ev.Entries[i]);
    	
        if (entries.Count > 0) // Set lastIndex for corresponding logType
            _lastIndices[logType] = entries.Max(e => e.Index);
   	
        foreach (EventLogEntry CurrentEntry in entry.OrderBy(e => e.TimeWritten))
        {
            Console.WriteLine("Event ID : " + CurrentEntry.EventID);
            Console.WriteLine("Event Source : " + CurrentEntry.Source);
            Console.WriteLine("Event TimeGenerated : " + CurrentEntry.TimeGenerated);
            Console.WriteLine("Event TimeWritten : " + CurrentEntry.TimeWritten);
            Console.WriteLine("Event MachineName : " + CurrentEntry.MachineName);
            Console.WriteLine("Entry Type : " + CurrentEntry.EntryType.ToString());
            Console.WriteLine("Message :  " + CurrentEntry.Message + "\n");
            Console.WriteLine("-----------------------------------------");
        }
    }
