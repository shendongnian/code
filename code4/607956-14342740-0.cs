    Dictionary<string, string[]> data = new Dictionary<string, string[]>();
    using (TextFieldParser parser = new TextFieldParser("C:\test.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
            try
            {
                string[] fields = parser.ReadFields();
                data[fields[0]] = fields;
            }
            catch (MalformedLineException ex)
            {
                // ...
            }
        }
    }
