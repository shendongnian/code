    public static int? ParseOrNull<int>(this string value) 
    {
        int result;
        var parsed = int.TryParse(value, out result);
        return parsed ? result : (T?)null;
    }
    public static long? ParseOrNull<long>(this string value) 
    {
        long result;
        var parsed = long.TryParse(value, out result);
        return parsed ? result : (T?)null;
    }
    // same for ulong, long, uint, ushort, short, byte, 
    // bool, float, double, decimal. Do I forget one ?
