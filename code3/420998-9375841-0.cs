    public void WriteLocalValue(string localKey, string curValue)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        KeyValueConfigurationElement k = config.AppSettings.Settings[localKey];
        if (k == null)
            config.AppSettings.Settings.Add(localKey, curValue);
        else
            k.Value = curValue;
        config.Save();
    }
    public string ReadLocalValue(string localKey, string defValue)
    {
        string v = defValue;
        try
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration Application.ExecutablePath);
            KeyValueConfigurationElement k = config.AppSettings.Settings[localKey];
            if (k != null) v = (k.Value == null ? defValue : k.Value);
                return v;
        }
        catch { return defValue; }
    }
