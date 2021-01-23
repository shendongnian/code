    public static IComparable GetDoubleOrIntValue<T>(this string str) 
                                            where T: IComparable, IConvertible
    {
        var thisType = default(T);
        var typeCode = thisType.GetTypeCode();
        if (typeCode == TypeCode.Double)
        {
            double d;
            double.TryParse(str, out d);
            return d;
        }
        else if (typeCode == TypeCode.Int32)
        {
            int i;
            int.TryParse(str, out i);
            return i;
        }
        return thisType;
    }
