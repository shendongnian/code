    try
    {
    	 ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
    }
    catch (ConfigurationErrorsException ex)
    {
    	string filename = ex.Filename;
    	_logger.Error(ex, "Cannot open config file");
    
    	if (File.Exists(filename) == true)
    	{
    		_logger.Error("Config file {0} content:\n{1}", filename, File.ReadAllText(filename));
    		File.Delete(filename);
    		_logger.Error("Config file deleted");
    		Properties.Settings.Default.Upgrade();
    		// Properties.Settings.Default.Reload();
    		// you could optionally restart the app instead
    	}
    	else
    	{
    		_logger.Error("Config file {0} does not exist", filename);
    	}
    }
