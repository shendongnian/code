    SettingsBase settings; // (ex. Settings.Default)
    
    public void SetOriginalFromDefault()
    {
        object defaultValue = settingsProperty.DefaultValue;
        defaultValue = copyValue(defaultValue, false);
        // We want to set the new value. It also triggers the INotifyPropertyChanged of settings, if the instance is from type ApplicationSettings
        settings[settingsProperty.Name] = defaultValue;
    }
