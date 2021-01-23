    //2 days
    TimeSpan daysToKeep = new TimeSpan(2,0,0,0);
    
    //The folder where the files are kept
    DirectoryInfo backupFolder = new DirectoryInfo(@"\\Fabtrol-2\Program Files (x86)\FabTrolBackUp\");
    //the Appendold.BAK file
    FileInfo backupLog = new FileInfo(backupFolder.FullName + @"\FT_Trans_Log_Appendedold.BAK");
    
    //the base name for the log files
    string logName = "FT_FabTrol_{0}_Full.BAK";
    //an array for the days of week that are part of the logname
    string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
    //get yesterday's log file name
    string yesterdayLog = String.Format(logName, days[(int)DateTime.Today.AddDays(-1).DayOfWeek]);
    //create file info
    FileInfo logFile = new FileInfo(backupFolder.FullName + yesterdayLog);
    
    //if the file exists, and it is less than 2 days old
    try
    {
    	if (logFile.Exists && (DateTime.Today - logFile.LastWriteTime < daysToKeep))
    	{
    		backupLog.Delete();
    		Console.WriteLine("success");
    	}
    	else
    	{
    		Console.WriteLine("log file either did not exist or is not ready to delete");
    	}
    }
    catch(Exception ex)
    {
    	Console.WriteLine(ex.Message);
    }
