    public static T CloneFieldsAndProperties<T>(T input)
    {
        T result = (T)Activator.CreateInstance(input.GetType());
        PropertyInfo[] properties = input.GetType().GetProperties();
        FieldInfo[] fields = input.GetType().GetFields();
        foreach (PropertyInfo property in properties)
            property.SetValue(result, property.GetValue(input, null), null);
        foreach (FieldInfo field in fields)
            field.SetValue(result, field.GetValue(input));
        return result;
    }
