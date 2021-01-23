    public static object ChangeType(object value, Type conversionType)
    {
       if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
       {
           if (value == null)
               return null;
           var nullableConverter = new NullableConverter(conversionType);
           conversionType = nullableConverter.UnderlyingType;
        }
        return Convert.ChangeType(value, conversionType);
     }
