    // "value" is some object with accessors like: format, channels, language
    row = new List<String> {
        JoinProperties(myObject.Audio, innerSeparator, x => x.format),
        JoinProperties(myObject.Audio, innerSeparator, x => x.channels),
        JoinProperties(myObject.Audio, innerSeparator, x => x.language),
    // ...
    }
    ...
    public string JoinProperties<TKey, TValue, TProperty>(IDictionary<TKey, TValue> dictionary, string separator, Func<TValue, TProperty> selector)
    {
        return string.Join(separator, dictionary.OrderBy(kvp => kvp.Key).Select(kvp => selector(kvp.Value)));
    }
