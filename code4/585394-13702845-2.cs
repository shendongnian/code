    public static IEnumerable<TEnum> AsEnumerable<TEnum>() where TEnum : struct
    {
        return AsEnumerable<TEnum, TEnum>(e => e);
    }
    public static IEnumerable<TResult> AsEnumerable<TEnum, TResult>(
        Func<TEnum, TResult> projection) where TEnum : struct
    {
        if (!typeof(TEnum).IsEnum)
            throw new InvalidOperationException("Type parameter TEnum must be an enum");
        return Enum.GetValues(typeof(TEnum)).OfType<TEnum>().Select(projection);
    }
