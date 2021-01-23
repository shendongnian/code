        private List<string> parseFields (string lineToParse)
        {
            //initialize a return variable
            List<string> result = new List<string>();
            //read the line into a MemoryStream
            byte[] bytes = Encoding.ASCII.GetBytes(lineToParse);
            MemoryStream stream = new MemoryStream(bytes);
            //use the VB TextFieldParser to do the work for you
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.Delimiters = new string[] { "," };
                parser.HasFieldsEnclosedInQuotes = true;
                //parse the fields
                while ( parser.EndOfData == false)
                {
                    result = parser.ReadFields().ToList();
                }
            }
            return result;
        }
