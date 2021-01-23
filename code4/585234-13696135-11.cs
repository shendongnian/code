    public static T GetEnumValue<T>(this string value) where T : struct
    {
        Type t = typeof(T);
        if (!t.IsEnum)
            throw new Exception("T must be an enum");
        else
        {
            T result;
            if (Enum.TryParse<T>(value, out result))
                return result;
            else
                return default(T);
        }
    }
