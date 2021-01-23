    public static int GetEnumValue<T>(T inputEnum) where T: struct, IConvertible
    {
        Type t = typeof(T);
        if (!t.IsEnum)
        {
            throw new ArgumentException("Input type must be an enum.");
        }
    
        return inputEnum.ToInt32(CultureInfo.InvariantCulture.NumberFormat);
    
    }
