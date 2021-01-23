    private static IEnumerable<string> ReadOnlyDateTime(string path)
    {
        DateTime d;
        string input;
        using (StreamReader stream = new StreamReader(path)) 
        {
            while ((input = stream.ReadLine() != null && DateTime.TryParse(input, out d))
            {
                yield return input;
            }
        }
    }
