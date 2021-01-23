    public static int EnumToInt<TValue>(TValue value)  where T : struct, IConvertible
    {
        if(!typeof(TValue).IsEnum)
        {
            throw new ArgumentException(nameof(value));
        }
        return (int)(object)value;
    }
