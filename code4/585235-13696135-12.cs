    public static T GetEnumValue<T>(this string value) where T : struct
    {
        Type t = typeof(T);
        if (!t.IsEnum)
            throw new Exception("T must be an enum");
        else
        {
            if (Enum.IsDefined(t, value))
                return (T)Enum.Parse(t, value);
            else
                return default(T);
        }
    }
