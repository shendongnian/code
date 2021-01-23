      public void ReadSqlAgentEventMessages()
            {
                // Force culture to en-US if required, some people get a null from FormatDescription() and this appently solves it. 
                // My culture is set as en-GB and I did not have the issue, so I have left it as a comment to possibly ease someone's pain!
                // Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    
                EventLogQuery eventlogQuery = new EventLogQuery("Application", PathType.LogName, "*[System/Provider/@Name=\"SQLSERVERAGENT\"]");
                EventLogReader eventlogReader = new EventLogReader(eventlogQuery);
    
                // Loop through the events returned
                for (EventRecord eventRecord = eventlogReader.ReadEvent(); null != eventRecord; eventRecord = eventlogReader.ReadEvent())
                {
                    // Get the description from the eventrecord. 
                    string message = eventRecord.FormatDescription();
    
                    // Do something cool with it :) 
                }
            }
