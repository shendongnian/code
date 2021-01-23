    static void Main(string[] args)
    {
        StringBuilder eventLogText = new StringBuilder();
        try
        {
            var eventLog = new EventLog("Application");
            var tenMostRecentEvents = eventLog.Entries
                                                .Cast<EventLogEntry>()
                                                .Reverse()
                                                .Take(10);
            foreach (EventLogEntry entry in tenMostRecentEvents)
            {
                eventLogText.AppendLine(String.Format("{0} - {1}: {2}", 
                                              entry.Source, 
                                              entry.TimeWritten, 
                                              entry.Message));
            }
            
            Console.WriteLine(eventLogText.ToString());
        }
        catch (System.Security.SecurityException ex)
        {
            Console.WriteLine(ex);
        }
        Console.ReadLine(); 
    }
