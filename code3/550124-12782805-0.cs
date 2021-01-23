    public static Object ChangeType(Object value, TypeCode typeCode , IFormatProvider provider)
    {
    
    IConvertible v = value as IConvertible;
    
    switch (typeCode) {
    
    case TypeCode.Boolean:
        return v.ToBoolean(provider);
    
    case TypeCode.Char:
        return v.ToChar(provider);
    
    case TypeCode.SByte:
        return v.ToSByte(provider);
    
    case TypeCode.Byte:
        return v.ToByte(provider);
    
    case TypeCode.Int16:
        return v.ToInt16(provider);
    
    case TypeCode.UInt16:
        return v.ToUInt16(provider);
    
    . . .
    
    }
