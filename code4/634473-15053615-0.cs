    public IEnumerable<MyClass> Parse(string path)
    {
        using (TextFieldParser parser = new TextFieldParser(path))
        {
            parser.CommentTokens = new string[] { "#" };
            parser.SetDelimiters(new string[] { ";" });
            parser.HasFieldsEnclosedInQuotes = true;
         
            // Skip over header line.
            parser.ReadLine();
         
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                yield return new MyClass()
                {
                    id = fields[0],
                    name = fields[1]
                };
            }
        }
    }
