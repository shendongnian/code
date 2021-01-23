    IEnumerable<string> ReadLines(string path)
    {
        string line;
        using (var sr = new StreamReader(path))
           while ( (line = sr.ReadLine()) != null)
               yield return line;
    }
