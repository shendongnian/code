       public static T GetDoubleOrIntValue<T>(this string str) where T : IConvertible
    {
        var thisType = default(T);
        var typeCode = thisType.GetTypeCode();
        if (typeCode == TypeCode.Double)
        {
            double d;
            double.TryParse(str, out d);
            return (T)Convert.ChangeType(d,typeCode) ;
        }
        else if (typeCode == TypeCode.Int32)
        {
            int i;
            int.TryParse(str, out i);
            return (T)Convert.ChangeType(i, typeCode);
        }
        return thisType;
    }
