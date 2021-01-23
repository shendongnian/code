    public static T[] ToArray<T>(this string s, params char[] seps)
       where T : IConvertible
    {
        Type targetType = typeof(T);
        return s.Split(seps.Length > 0 ? seps : new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Cast<IConvertible>()
                        .Select(ic => ic.ToType(targetType, CultureInfo.InvariantCulture))
                        .Cast<T>()
                        .ToArray();
    }
