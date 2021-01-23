    using (TextFieldParser parser = new TextFieldParser(path))
    {
        parser.Delimiters = new string[] {","};
        parser.TextFieldType = Delimited;
        parser.HasFieldsEnclosedInQuotes = true;
        string[] parsedLine;
        while (!parser.EndOfData)
        {
            parsedLine = parser.ReadFields();
            Event special = new Event();
            special.Day = Convert.ToInt32(parsedLine[0]);
            special.Time = Convert.ToDateTime(parsedLine[1]);
            special.Price = Convert.ToDouble(parsedLine[2]);
            special.StrEvent = parsedLine[3];
            special.Description = parsedLine[4];
            events.Add(special);    
        }
    }
