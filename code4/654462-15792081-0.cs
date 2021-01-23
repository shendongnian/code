    //write the last run time to config
	Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	if (config.AppSettings.Settings["LastRunTime"] == null)
	{
		config.AppSettings.Settings.Add("LastRunTime", DateTime.UtcNow.ToString());
	}
	else
	{
		config.AppSettings.Settings["LastRunTime"].Value = DateTime.UtcNow.ToString();
	}
	config.Save();
