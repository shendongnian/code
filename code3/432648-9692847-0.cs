		public static string Left(this string input, int length)
		{
			string result = input;
			if (input != null && input.Length > length)
			{
				result = input.Substring(0, length);
			}
			return result;
		}
