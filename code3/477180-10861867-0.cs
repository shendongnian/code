    public static IEnumerable<T> SplitConvert<T>(this string str, params char[] delimiters)
    {
        var converter = TypeDescriptor.GetConverter(typeof(T));
        if (converter.CanConvertFrom(typeof(string)))
        {
            return str.Split(delimiters).Select(s => (T)converter.ConvertFromString(s));
        }
        else throw new InvalidOperationException("Cannot convert type");
    }
