    TimeSpan daysToKeep = new TimeSpan(2,0,0,0); //2 days
    DirectoryInfo backupFolder = new DirectoryInfo(@"\\Fabtrol-2\Program Files (x86)\FabTrolBackUp\");  
    foreach (var file in backupFolder.GetFiles())
    {
    	if ((DateTime.Today - file.LastWriteTime.Date) > daysToKeep)
    	{
    		try
    		{
    			file.Delete();
    			Console.WriteLine("File Deleted");
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex.Message);
    		}
    	}
    }
