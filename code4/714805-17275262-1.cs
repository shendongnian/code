    static IEnumerable<string> ReadFrom(string filename)
    {
        using (var reader = File.OpenText(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
