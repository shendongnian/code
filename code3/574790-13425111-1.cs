    private static string BuildCheat<T>(
        IEnumerable<T> source,
        string delimiter,
        string prefix,
        string suffix)
    {
        var builder = new StringBuilder(32);
        builder = builder.Append(prefix);
    
        using (var e = source.GetEnumerator())
        {
            if (e.MoveNext())
            {
                builder.Append(e.Current);
            }
    
            while (e.MoveNext())
            {
                builder.Append(delimiter);
                builder.Append(e.Current);
            }
        }
    
        builder.Append(suffix);
        return builder.ToString();
    }
