    private static IEnumerable<string> GetLines(TextReader reader)
    {
        while (!reader.EndOfStream)
        {
             yield return reader.ReadLine();
        }
    }
    
    private static CultureInfo ci = CultureInfo.InvariantCulture;
    
    public static ConcurrentBag ProcessData(TextReader reader)
    {
        ConcurrentBag <DateTime> results = new ConcurrentBag <DateTime>();
        char[] seperators = {' '};
        Parallel.ForEach(GetLines(reader), line =>
        {
            //We only need the first field so limit the split to 2
            string[] fields = line.Split(seperators, 2);
            results.Enqueue(DateTime.ParseExact(fields[0], "yyyyMMddTHHmmssfff", ci));
        });
        return results
    }
