	[Conditional("DEBUG")]
 	public static bool IsValid(this System.Enum value)
	{
		if (!System.Enum.IsDefined(value.GetType(), value))
			throw new EnumerationValueNotSupportedException(value.GetType(), value); //custom exception
	}
