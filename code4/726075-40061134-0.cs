	namespace System
	{
		public static class StringExtensions
		{
			public static string PadCenter(this string str, int totalLength, char padChar = '\u00A0')
			{
				int padAmount = totalLength - str.Length;
				if (padAmount <= 1)
				{
					if (padAmount == 1)
					{
						return str.PadRight(totalLength);
					}
					return str;
				}
				int padLeft = padAmount/2 + str.Length;
				return str.PadLeft(padLeft).PadRight(totalLength);
			}
		}
	}
