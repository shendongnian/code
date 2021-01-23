    public static IEnumerable<string> ReadLines(this TextReader reader)
    {
        string line = null;
        while((line = reader.ReadLine()) != null) 
        {
            // do something with line
        }
    }
