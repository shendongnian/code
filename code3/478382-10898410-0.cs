	public static string SanitizeFileName(string fileName, char replacementChar = '_')
	{
		var invalidCharacters = System.IO.Path.GetInvalidFileNameChars();
		var output = fileName.ToCharArray();
		for (int i = 0, ln = output.Length; i < ln; i++)
		{
			if (invalidCharacters.Contains(output[i]))
			{
				output[i] = replacementChar;
			}
		}
		return new String(output);
	}
