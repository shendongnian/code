    private void ParseAppSettings() {
    	string value = string.Empty;
    	foreach (string key in System.Configuration.ConfigurationManager.AppSettings.AllKeys)
    	{
    		value = System.Configuration.ConfigurationManager.AppSettings[key];
    		Console.WriteLine("Key: {0} Value: {1}", key, value);
    	} 
    }
