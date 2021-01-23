    static void CopyTo<T>(T from, T to)
    {
        foreach (PropertyInfo property in typeof(T).GetProperties())
        {
            if (!property.CanRead || !property.CanWrite || (property.GetIndexParameters().Length > 0))
                continue;
            object value = property.GetValue(to);
            if (value != null)
                property.SetValue(to, property.GetValue(from));
        }
    }
