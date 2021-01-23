    Type t = myEnumPropertyInfo.PropertyType;
    if (t.GetGenericTypeDefinition() == typeof(Nullable<>))
    {
        t = t.GetGenericArguments().First();
    }
