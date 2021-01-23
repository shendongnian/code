    public class StorageSettingsApplication
    {
        public StorageSettingsApplication()
        {
            try
            {
                localSettings = ApplicationData.Current.LocalSettings;
            }
            catch (Exception)
            {
            }
        }
        ApplicationDataContainer localSettings;
        publicTValue TryGetValueWithDefault<TValue>(string key, TValue defaultvalue)
        {
            TValue value;
            // If the key exists, retrieve the value.
            if (localSettings.Values.ContainsKey(key))
            {
                value = (TValue)localSettings.Values[key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultvalue;
            }
            return value;
        }
        public bool AddOrUpdateValue(string key, object value)
        {
            bool valueChanged = false;
            // If the key exists
            //if (localSettings.Contains(Key))
            if (localSettings.Values.ContainsKey(key))
            {
                // If the value has changed
                if (localSettings.Values[key] != value)
                {
                    // Store the new value
                    localSettings.Values[key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                localSettings.Values.Add(key, value);
                valueChanged = true;
            }
            return valueChanged;
        }
    }
