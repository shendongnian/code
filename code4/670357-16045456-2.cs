    public static double CalculateStandardDeviation<TSource>(IEnumerable<TSource> inputs)
    {
        var converter = TypeDescriptor.GetConverter(typeof (double));
        if (!converter.CanConvertFrom(typeof(TSource)))
            return 0;
    
        var values = new List<double>();
        foreach (var value in inputs)
        {
            values.Add((double) converter.ConvertFrom(value));
        }
    
        // Your logic here ...
        return ...;
    }
