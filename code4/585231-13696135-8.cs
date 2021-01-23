    public static T GetEnumValue<T>(this int value) where T : struct
    {
        Type t = typeof(T);
        if (!t.IsEnum)
            throw new Exception("T must be an enum");
        else
        {
            if (Enum.IsDefined(t, value))
                return (T)(object)value;
            else
                return default(T);
        }
    }
