    public static IEnumerable<char> ReadCharacters(string filename)
    {
        using (var reader = File.OpenText(filename))
        {
            int readResult;
            while ((readResult = reader.Read()) != -1)
            {
                yield return (char) readResult;
            }
        }
    }
    ...
    foreach (char c in ReadCharacters("foo.txt"))
    {
        ...
    }
