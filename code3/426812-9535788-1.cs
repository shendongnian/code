    private void MyApp_Launching()
    {
         // Get the settings for this application.
         settings = IsolatedStorageSettings.ApplicationSettings;
         if (GetValueOfDefault<bool>(IsAppFirstRunKey, IsAppFirstRunDefaultVal))
             AddOrUpdateValue<bool>(IsAppFirstRunKey, false);
    }
             
    public T GetValueOrDefault<T>(string Key, T defaultValue)
    {
        T value;
        // If the key exists, retrieve the value.
        if (settings.Contains(Key))
        {
            value = (T)settings[Key];
        }
        // Otherwise, use the default value.
        else
        {
            value = defaultValue;
        }
        return value;
    }
    public bool AddOrUpdateValue(string Key, Object value)
    {
        bool valueChanged = false;
        // If the key exists
        if (settings.Contains(Key))
        {
            // If the value has changed
            if (settings[Key] != value)
            {
                // Store the new value
                settings[Key] = value;
                valueChanged = true;
            }
        }
        // Otherwise create the key.
        else
        {
            settings.Add(Key, value);
            valueChanged = true;
        }
        return valueChanged;
    }
