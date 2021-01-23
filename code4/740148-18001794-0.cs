	private void processImport()
	{
		string[] fields;
		string field ;
		string temp = "";
		byte[] tempByte;
		TextFieldParser parser = new TextFieldParser(textbox_csv.Text, System.Text.Encoding.UTF8);
		parser.TextFieldType = FieldType.Delimited;
		parser.SetDelimiters(";");
		
		while (!parser.EndOfData)
		{
			fields = parser.ReadFields();
			field = fields[0];
			temp = RemoveDiacritics(field).ToUpper();
			//this line is very important. It seems to change the Encoding of my string to Unicode.
			temp = temp.Normalize(NormalizationForm.FormC);
			field = myVbDll.MyWrappedFunction(temp, false);
		}
		parser.Close();
	}
	//Transforms the culture of a letter to its equivalent representation in the 0-127 ascii table, such as the letter 'é' is substituted by an 'e'
	public string RemoveDiacritics(string s)
	{
		string normalizedString = null;
		StringBuilder stringBuilder = new StringBuilder();
		normalizedString = s.Normalize(NormalizationForm.FormD);
		int i = 0;
		char c = '\0';
		
		for (i = 0; i <= normalizedString.Length - 1; i++)
		{
			c = normalizedString[i];
			if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
			{
				stringBuilder.Append(c);
			}
		}
		
		return stringBuilder.ToString().ToLower();
	}
