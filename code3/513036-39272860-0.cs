	public void ResetOneSetting(string propertyName)
	{
		SettingsPropertyValue propertyToReset = Settings.Default.PropertyValues.OfType<SettingsPropertyValue>().FirstOrDefault(p => p.Name == propertyName);
		if (propertyToReset != null)
		{
			propertyToReset.PropertyValue = propertyToReset.Property.DefaultValue;
			propertyToReset.Deserialized = false;
		}
	}
