	public static class StringBuilderExtensions
	{
    #if EXTENSIONS_SUPPORTED
		public static StringBuilder ReplaceAt(this StringBuilder sb, string value, int index, int count)
		{
			return StringBuilderExtensions.ReplaceAt(sb, value, index, count);
		}
    #endif
		public static StringBuilder ReplaceAt(StringBuilder sb, string value, int index, int count)
		{
			if (value == null)
			{
				sb.Remove(index, count);
			}
			else
			{
				int lengthOfValue = value.Length;
				if (lengthOfValue > count)
				{
					string valueToInsert = value.Substring(count);
					sb.Insert(index + count, valueToInsert);
				}
				if (lengthOfValue < count)
				{
					sb.Remove(index + count, lengthOfValue - count);
				}
				char[] valueChars = value.ToCharArray();
				for (int i = 0; i < lengthOfValue; i++)
				{
					sb[index + i] = valueChars[i];
				}
			}
			return sb;
		}
	}
