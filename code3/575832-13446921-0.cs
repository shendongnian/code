    public static bool OnlyTheseFlagsSet<T>(this T input, params T[] values) where T : struct, IConvertible
    {
        int enumVal = input.ToInt32(null);
        foreach (T itm in values)
        {
            int val = itm.ToInt32(null);
            enumVal = enumVal ^ val;                
        }
        return (enumVal == 0);
    }
