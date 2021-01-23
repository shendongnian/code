	namespace ExtensionMethods
	{
		public static class StringExtensions
		{
			public static decimal ToDecimalOrZero(this String str)
			{
				decimal dec = 0;
				Decimal.TryParse(str, out dec);
				return dec;
			}
		}   
	}
	
	using ExtensionMethods;
	//...
	decimal dec = "154".ToDecimalOrZero(); //dec == 154
	decimal dec = "foobar".ToDecimalOrZero(); //dec == 0
