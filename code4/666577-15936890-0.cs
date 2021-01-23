	internal static void ValidateOnlyIncomingFields(this ModelStateDictionary modelStateDictionary, FormCollection formCollection)
	{
		IEnumerable<string> keysWithNoIncomingValue = null;
		IValueProvider valueProvider = null;
		try
		{
			// Transform into a value provider for linq/iteration.
			valueProvider = formCollection.ToValueProvider();
			// Get all validation keys from the model that haven't just been on screen...
			keysWithNoIncomingValue = modelStateDictionary.Keys.Where(keyString => !valueProvider.ContainsPrefix(keyString));
			// ...and clear them.
			foreach (string errorKey in keysWithNoIncomingValue)
				modelStateDictionary[errorKey].Errors.Clear();
		}
		catch (Exception exception)
		{
			Functions.LogError(exception);
		}
	}
