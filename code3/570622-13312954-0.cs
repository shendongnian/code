    public IEnumerable<string> ReadLines(Func<Stream> streamProvider,
                                         Encoding encoding)
    {
        using (var stream = streamProvider())
        using (var reader = new StreamReader(stream, encoding))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
