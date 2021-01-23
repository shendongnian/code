    <appSettings>
        <add key="customsetting1" value="Some text here"/>
    </appSettings>
        
    System.Configuration.Configuration rootWebConfig1 =    				 
        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
        
    if (rootWebConfig1.AppSettings.Settings.Count > 0)
    {
        System.Configuration.KeyValueConfigurationElement customSetting = 
        	rootWebConfig1.AppSettings.Settings["customsetting1"];
        if (customSetting != null)
            Console.WriteLine("customsetting1 application string = \"{0}\"",   
                customSetting.Value);
        else
        	Console.WriteLine("No customsetting1 application string");
    }
