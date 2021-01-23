	public static List<byte> RemoveEscapeSequences(List<byte> message)
	{
		List<byte> result = new List<byte>(message.Count);
		bool escape = false;
		foreach (byte value in message)
		{
			if (escape)
			{
				escape = false;
				// Replace the byte. NOTE 1!
				result.Add(EscapeBytes[value]);
			}
			else if (value == 0xF8)
			{
				// Started an escape sequence.
				escape = true;
			}
			else
			{
				// Just add the byte.
				result.Add(value);
			}
		}
		return result;
	}
	
