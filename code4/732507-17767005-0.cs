    private string[] ParseCsv(string line)
        {
            var parser = new TextFieldParser(new StringReader(line));
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                return parser.ReadFields();
            }
            parser.Close();
            return new string[0];
        }
