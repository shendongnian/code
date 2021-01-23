    SettingsBase settings; // (ex. Settings.Default)
    
    public void SetOriginalFromDefault()
    {
        object defaultValue = settingsProperty.DefaultValue;
        defaultValue = copyValue(defaultValue, false);
        settings[settingsProperty.Name] = defaultValue;
    }
