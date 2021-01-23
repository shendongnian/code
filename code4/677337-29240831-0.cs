            using (TextFieldParser parser = new TextFieldParser(reader))
            {
                parser.Delimiters = new[] { "," };
                while (!parser.EndOfData)
                {
                    string[] fields = null;
                    try
                    {
                        fields = parser.ReadFields();
                        
                    }
                    catch (MalformedLineException ex)
                    {
                        if (parser.ErrorLine.StartsWith("\""))
                        {
                            var line = parser.ErrorLine.TrimStart('"').TrimEnd('"');
                            fields = line.Split(new string[] {"\",\""}, StringSplitOptions.None);
                        }
                        else
                        {
                            throw;
                        }
                    }
                    Console.WriteLine("This line was parsed as:\n{0},{1}", fields[0], fields[1]);
                }
            }
