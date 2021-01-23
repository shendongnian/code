	namespace System
	{
		public static class StringExtensions
		{
			public static string PadSides(this string str, int totalWidth, char paddingChar = ' ')
			{
				int padding = totalWidth - str.Length;
				int padLeft = padding / 2 + str.Length;
				return str.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
			}
		}
	}
