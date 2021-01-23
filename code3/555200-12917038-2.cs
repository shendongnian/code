	[Conditional("DEBUG")]
 	public static bool AssertIsValid(this System.Enum value)
	{
		if (!System.Enum.IsDefined(value.GetType(), value))
			throw new EnumerationValueNotSupportedException(value.GetType(), value); //custom exception
	}
