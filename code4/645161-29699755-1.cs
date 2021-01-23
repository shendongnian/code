    public static ConfigurationSettings SetConfigurationSettings
    {
        ConfigurationSettings configurationsettings = new   ConfigurationSettings();
        {
            foreach (var prop in  configurationsettings.GetType().GetProperties())
            {
                string property = (prop.Name.ToString());
                string value = ConfigurationManager.AppSettings[property];
                PropertyInfo propertyInfo = configurationsettings.GetType().GetProperty(prop.Name);
                propertyInfo.SetValue(configurationsettings, value, null);
            }
        }
        return configurationsettings;
     }
