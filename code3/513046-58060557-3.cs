    private SettingsPropertyValue settingsPropertyValue; // (ex. Settings.Default.PropertyValues["anyPropertyName"])
    
    private SettingsProperty settingsProperty 
                => settingsPropertyValue.Property;
     
    /// <summary>
    /// Create a deep copy of <paramref name="value"/>.
    /// </summary>
    /// <param name="value">
    /// Should be a deserialized value (ex. <see cref="SettingsPropertyValue.PropertyValue"/>) 
    /// or a serialized value (ex. <see cref="SettingsProperty.DefaultValue"/>).
    /// </param>
    /// <param name="isDeserialized">Indicates whether <paramref name="value"/> is deserialized or serialized.</param>
    private PropertyType copyValue<PropertyType>(object value, bool isDeserialized)
    {
        var temporaryPropertyValue = settingsPropertyValue.PropertyValue;
        settingsPropertyValue.PropertyValue = value;
    
        if (isDeserialized)
            // We have to reassign, otherwise PropertyValue/SerializedValue of SettingsPropertyValue may be defaulted
            settingsPropertyValue.SerializedValue = settingsPropertyValue.SerializedValue; 
    
        settingsPropertyValue.Deserialized = false;
        var propertyValue = (PropertyType)settingsPropertyValue.PropertyValue;
        settingsPropertyValue.PropertyValue = temporaryPropertyValue;
        return propertyValue;
    }
