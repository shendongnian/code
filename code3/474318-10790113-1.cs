	public static double Parse(string s, NumberStyles style, IFormatProvider provider)
	{
		NumberFormatInfo.ValidateParseStyleFloatingPoint(style);
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
		double result = 0.0;
		try
		{
			Number.ParseDouble(s, style, instance, true, ref result);
			return result;
		}
		catch (FormatException)
		{
			string str = s.Trim();
			if (str.Equals(instance.PositiveInfinitySymbol))
			{
				return PositiveInfinity;
			}
			if (str.Equals(instance.NegativeInfinitySymbol))
			{
				return NegativeInfinity;
			}
			if (!str.Equals(instance.NaNSymbol))
			{
				throw;
			}
			return NaN;
		}
	}
