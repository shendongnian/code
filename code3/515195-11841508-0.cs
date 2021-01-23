	using (var reader = new TextFieldParser(@"c:\YourFile"))
	{
		reader.TextFieldType = FieldType.Delimited;
		reader.Delimiters = new string[] {","};
		string[] currentRow = null;
		while (!reader.EndOfData)
		{
			try
			{
				currentRow = reader.ReadFields();
                // do something with the values
			}
			catch (MalformedLineException ex)
			{
				// skip invalid lines and handle it
			}
		}
	}
