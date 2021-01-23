    private static string AsString<T>(this T values)
    {
        Enum v = (Enum)Convert.ChangeType(values, typeof(Enum));
        Array array = Enum.GetValues(typeof(T));
        IEnumerable<Enum> setFlags = array
            .Cast<Enum>()
            .Where(c => v.HasFlag(c) && IsDistinctValue(c));
    
        return values.Equals(default(T))
            ? default(T).ToString()
            : string.Join("|", setFlags.Where(c => Convert.ToInt32(c) != 0).Select(c => c.ToString()));
    }
    
    private static bool IsDistinctValue(Enum value)
    {
        int current = Convert.ToInt32(value) << 1;
        while (current > 0)
        {
            if ((Convert.ToInt32(value) & current) != 0)
            {
                return false;
            }
            current <<= 1;
        }
    
        return true;
    }
