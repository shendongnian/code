    public static NameValueCollection AppSettings
    {
    	get
    	{
    		object section = ConfigurationManager.GetSection("appSettings");
    		if (section == null || !(section is NameValueCollection))
    		{
    			throw new ConfigurationErrorsException(SR.GetString("Config_appsettings_declaration_invalid"));
    		}
    		return (NameValueCollection)section;
    	}
    }
