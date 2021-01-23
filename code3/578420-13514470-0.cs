    public static string ToString(Object value) {
        return ToString(value,null);
    }
    public static string ToString(Object value, IFormatProvider provider) { 
        IConvertible ic = value as IConvertible; 
        if (ic != null)
            return ic.ToString(provider); 
        IFormattable formattable = value as IFormattable;
        if (formattable != null)
            return formattable.ToString(null, provider);
        return value == null? String.Empty: value.ToString(); 
    }
