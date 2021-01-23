	// ...
	catch (FaultException ex)
	{
		Type exceptionType = ex.GetType();
		if (exceptionType.IsGenericType)
		{
			// Find the type of the generic parameter
			Type genericType = ex.GetType().GetGenericArguments().FirstOrDefault();
			if (genericType != null)
			{
				// TODO: Handle the generic type.
			}
		}
	}
