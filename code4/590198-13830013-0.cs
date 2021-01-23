    private static string CreateColumnString(Colors values)
    {
        Colors[] array = (Colors[])Enum.GetValues(typeof(Colors));
        IEnumerable<Colors> setFlags = array.Where(c => values.HasFlag(c) && IsDistinctValue(c));
        return values == Colors.None 
            ? "None" 
            : string.Join("|", setFlags.Where(c => c != Colors.None).Select(c => c.ToString()));
    }
    
    private static bool IsDistinctValue(Colors value)
    {
        int current = (int)value;
        while (--current > 0)
        {
            if (value.HasFlag((Colors)current))
            {
                return false;
            }
        }
    
        return true;
    }
