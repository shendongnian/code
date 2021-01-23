    public static string ToString(this IDictionary source, string keyValueSeparator,
                                                           string sequenceSeparator) 
    { 
        if (source == null) 
            throw new ArgumentException("Parameter source can not be null."); 
 
        return source.Cast<DictionaryEntry>()
                     .Aggregate(new StringBuilder(),
                                (sb, x) => sb.Append(x.Key + keyValueSeparator + x.Value
                                                      + sequenceSeparator),
                                sb => sb.ToString(0, sb.Length - 1));            
    } 
