	public bool IsAllowed(AppAll value)
	{
		return value == AppAll.Data2
		    || value == AppAll.Data16
			|| value == AppAll.Data42;
	}
	
	if (!IsAllowed(value))
		throw new ArgumentException("Enum value not allowed.");
