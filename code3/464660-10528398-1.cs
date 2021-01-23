    public IEnumerable<string> ReadLines(Stream stream)
    {
        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
        {
            while (!reader.EndOfStream)
                yield return reader.ReadLine();
        }
    }
