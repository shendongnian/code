    private static IDictionary<string, int> ParseNameFile(string filename)
    {
        var names = new Dictionary<string, int>();
        using (var reader = new StreamReader(filename))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                if (names.ContainsKey(line))
                {
                    names[line]++;
                }
                else
                {
                    names.Add(line, 1);
                }
                line = reader.ReadLine(); 
            }
        }
    }
