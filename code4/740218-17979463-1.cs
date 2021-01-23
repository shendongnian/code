    IEnumerable<string> ReadWhiteSpaceSeparated(string filename)
    {
        using(var lines = File.ReadLines(filename))
        {
            return lines.SelectMany(line => line.Split(' ','\t'));
        }
    }
    IEnumerable<string> ReadDoubles(string filename)
    {
         return ReadWhiteSpaceSeparated(filename)
             .Select(s => double.Parse(s, CultureInfo.InvariantCulture));
    }
