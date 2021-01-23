    public void ConfigChanged(object sender, FileSystemEventArgs e)
    {
    	try
    	{
    		this.fileSystemWatcher.EnableRaisingEvents = false;
    		s_logger.Info("Configuration file changed.");
    		// reload config here
    		s_logger.Info("Configuration settings reloaded.");
    	}
    	catch (Exception exception)
    	{
    		s_logger.Error(exception.Message);
    		s_logger.Error("Failed to reload configuration settings.");
    	}
    	finally
    	{
    		this.fileSystemWatcher.EnableRaisingEvents = true;
    	}
    }
