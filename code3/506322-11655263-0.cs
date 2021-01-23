	private string LoadXml(string FileName)
	{
		try
		{
			using (StreamReader reader = new StreamReader(FileName))
			{
				return reader.ReadToEnd();
			}
		}
		catch
		{
			return string.Empty;
		}
	}
