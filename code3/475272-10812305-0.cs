    using (var csvParser = new TextFieldParser(new StringReader(content))
								 {
									 Delimiters = new[] {","},
									 HasFieldsEnclosedInQuotes = true
								 })
	{
		while (!csvParser.EndOfData)
		{
			var fields = csvParser.ReadFields();
			Console.Print(fields[0]); //do something with the first (in your case only) field found.
		}
	}
