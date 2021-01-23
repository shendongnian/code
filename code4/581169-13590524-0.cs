    public static DateTime RandomDate(Random generator, DateTime rangeStart, DateTime rangeEnd)
    {
        TimeSpan span = rangeEnd - rangeStart;
    
        int randomMinutes = generator.Next(0, (int)span.TotalMinutes);
        return rangeStart + TimeSpan.FromMinutes(randomMinutes);
    }
