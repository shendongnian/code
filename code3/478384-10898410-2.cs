	public static string SanitizeFileName(string fileName, char replacementChar = '_')
	{
		var blackList = new HashSet<char>(System.IO.Path.GetInvalidFileNameChars());
		var output = fileName.ToCharArray();
		for (int i = 0, ln = output.Length; i < ln; i++)
		{
			if (blackList.Contains(output[i]))
			{
				output[i] = replacementChar;
			}
		}
		return new String(output);
	}
