    public static Type GetUnderlyingType(Type nullableType)
    {
      if (nullableType == null)
        throw new ArgumentNullException("nullableType");
      Type type = (Type) null;
      if (nullableType.IsGenericType && !nullableType.IsGenericTypeDefinition && nullableType.GetGenericTypeDefinition() == typeof (Nullable<>))
        type = nullableType.GetGenericArguments()[0];
      return type;
    }
