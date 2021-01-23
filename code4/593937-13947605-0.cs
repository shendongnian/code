    public static class DoubleExtensions
	{
	 	public static double ParseDouble (this string value)
		{
			if (string.IsNullOrWhitespace(value))
				return 0.0;
		
			return Double.Parse(value);
		}
	}
