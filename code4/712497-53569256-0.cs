	using (var parser = new CsvParser(textReader)
	{
        while(true)
        {
		    string[] line = parser.Read();
            if (line != null)
            {
                // do something
            }
            else
            {
                break;
            }
        }
	}
