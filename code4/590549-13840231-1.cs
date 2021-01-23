    private static IEnumerable<FxCopErrorCodes> GetMatchingValues(FxCopErrorCodes enumValue)
    {
    	// Special case for 0, as it always match using the bitwise AND operation
    	if (enumValue == 0)
    	{
    		yield return FxCopErrorCodes.NoErrors;
    	}
    
    	// Gets list of possible values for the enum
    	var values = Enum.GetValues(typeof(FxCopErrorCodes)).Cast<FxCopErrorCodes>();
    
    	// Iterates over values and return those that match
    	foreach (var value in values)
    	{
    		if (value > 0 && (enumValue & value) == value)
    		{
    			yield return value;
    		}
    	}
    }
