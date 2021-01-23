    static void TrimObjectValues(object instance)
    {
        if (instance == null)
        {
            return;
        }
        var props = instance
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            // Ignore indexers
            .Where(prop => prop.GetIndexParameters().Length == 0)
            // Must be both readable and writable
            .Where(prop => prop.CanWrite && prop.CanRead);
        if (instance is IEnumerable)
        {
            foreach (var element in (IEnumerable)instance)
            {
                TrimObjectValues(element);
            }
            return;
        }
        foreach (PropertyInfo prop in props)
        {
            if (prop.PropertyType == typeof(string))
            {
                string value = (string)prop.GetValue(instance, null);
                if (value != null)
                {
                    value = value.Trim();
                    prop.SetValue(instance, value, null);
                }
            }
            else
            {
                TrimObjectValues(prop.GetValue(instance, null));
            }
        }
    }
