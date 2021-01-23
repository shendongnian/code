    private static IDictionary<Type,Func<string,object>> Converters = new Dictionary<Type,Func<string,object>> {
        {typeof(int), s => Convert.ChangeType(System.Convert.ToInt32(s), typeof(int))}
    ,   {typeof(decimal), s => Convert.ChangeType((decimal)System.Convert.ToInt32(s) / 100, typeof(decimal))}
    ,   ... // And so on
    };
    public static T Read<T>(this ByteContainer ba, int size, string format) where T : struct, IConvertible {
        Func<string,object> converter;
        if (!Converters.TryGetValue(typeof(T), out converter)) {
            throw new ArgumentException("Unsupported type: "+typeof(T));
        }
        var s = string.Concat(ba.Bytes.Select(b => b.ToString(format)).ToArray());
        return (T)converter(s);
    }
