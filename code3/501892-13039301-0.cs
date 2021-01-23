		/// <summary>
		/// Remove illegal XML characters from a string.
		/// </summary>
    	public static string SanitizeString(string s)
    	{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}
			StringBuilder buffer = new StringBuilder(s.Length);
			for (int i = 0; i < s.Length; i++)
			{
				int code;
				try
				{
					code = Char.ConvertToUtf32(s, i);
				}
				catch (ArgumentException)
				{
					continue;
				}
				if (IsLegalXmlChar(code))
					buffer.Append(Char.ConvertFromUtf32(code));
				if (Char.IsSurrogatePair(s, i))
					i++;
			}
			return buffer.ToString();
    	}
		/// <summary>
		/// Whether a given character is allowed by XML 1.0.
		/// </summary>
		private static bool IsLegalXmlChar(int codePoint)
		{
			return (codePoint == 0x9 ||
				codePoint == 0xA ||
				codePoint == 0xD ||
				(codePoint >= 0x20 && codePoint <= 0xD7FF) ||
				(codePoint >= 0xE000 && codePoint <= 0xFFFD) ||
				(codePoint >= 0x10000/* && character <= 0x10FFFF*/) //it's impossible to get a code point bigger than 0x10FFFF because Char.ConvertToUtf32 would have thrown an exception
			);
		}
