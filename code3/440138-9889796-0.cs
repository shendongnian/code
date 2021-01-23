    TextFieldParser parser = new TextFieldParser(@"c:\file.csv");
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters(",");
    while (!parser.EndOfData) 
    {
        //Processing row
        string[] fields = parser.ReadFields();
        foreach (string field in fields) 
        {
            //TODO: Do whatever you need
        }
    }
    parser.Close();
