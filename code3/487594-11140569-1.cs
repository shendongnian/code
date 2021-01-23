    Datetime dateX;
    System.Configuration.Configuration rootWebConfig1 = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
	if (rootWebConfig1.AppSettings.Settings.Count > 0)
	{
	    	System.Configuration.KeyValueConfigurationElement customSetting = 		rootWebConfig1.AppSettings.Settings["DateX"];
 	        if (customSetting != null)
            {
              dateX = Datetime.Parse(customSetting.Value);
            }
	}
