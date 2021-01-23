    public bool CreateLog(string strLogName)
    {
        bool Result = false;
        try
        {
                System.Diagnostics.EventLog.CreateEventSource(strLogName, strLogName);
                System.Diagnostics.EventLog SQLEventLog = 
				new System.Diagnostics.EventLog();
                SQLEventLog.Source = strLogName;
                SQLEventLog.Log = strLogName;
                SQLEventLog.Source = strLogName;
                SQLEventLog.WriteEntry("The " + strLogName + " was successfully 
			initialize component.", EventLogEntryType.Information);
                Result = true;
        }
        catch
        {
            Result = false;
        }
        return Result;
    }
