        string input; // Test string
        // Replace new StringReader with a StreamReader to read a file
        using (TextReader textReader = new StringReader(input))
        {
            // Read first line to get structure
            var groupings = textReader.ReadLine().GroupBy(x => x);
            while (textReader.Peek() != -1)
            {
                // Convert to a string for easier handling than char[]
                List<string> fields = new List<string>();
                // Get the fields on each ling
                foreach (IGrouping<char, char> grouping in groupings)
                {
                    char[] field = new char[grouping.Count()];
                    textReader.Read(field, 0, field.Length);
                    fields.Add(new string(field));
                }
                // Do something with "fields". The name of each field is
                // in grouping.Key at the same index.
                // Move to next line
                textReader.ReadLine();
            }
        }
