    using (var parser =
        new TextFieldParser(@"c:\data.csv")
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new[] { "," }
            })
    {
        while (!parser.EndOfData)
        {
            string[] fields;
            fields = parser.ReadFields();
            //go go go!
        }
    }
