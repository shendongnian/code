    public void QueryRemoteComputer()
        {
            string queryString = "*[System/Level=2]"; // XPATH Query
            SecureString pw = GetPassword();
    
            EventLogSession session = new EventLogSession(
                "RemoteComputerName",                               // Remote Computer
                "Domain",                                  // Domain
                "Username",                                // Username
                pw,
                SessionAuthentication.Default);
    
            pw.Dispose();
    
            // Query the Application log on the remote computer.
            EventLogQuery query = new EventLogQuery("Application", PathType.LogName, queryString);
            query.Session = session;
    
            try
            {
                EventLogReader logReader = new EventLogReader(query);
    
                // Display event info
                DisplayEventAndLogInformation(logReader);
            }
            catch (EventLogException e)
            {
                Console.WriteLine("Could not query the remote computer! " + e.Message);
                return;
            }
        }
