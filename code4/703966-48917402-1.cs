    public static int GetEnumValue(object enumInput)
    {
        Type t = enumInput.GetType();
        if (!t.IsEnum)
        {
            throw new ArgumentException("Input type must be an enum.");
        }
    
        return ((IConvertible)inputEnum).ToInt32(CultureInfo.InvariantCulture.NumberFormat);
    
    }
