    public static int EnumToInt<TValue>(TValue value)  where TValue : struct, IConvertible
    {
        if(!typeof(TValue).IsEnum)
        {
            throw new ArgumentException(nameof(value));
        }
        return (int)(object)value;
    }
