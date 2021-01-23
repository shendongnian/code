    static void TrimObjectValues(object instance)
    {
        // if the instance is null we have nothing to do here
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
        foreach (PropertyInfo prop in props)
        {
            if (prop.PropertyType == typeof(string))
            {
                // if we have a string property we trim it
                string value = (string)prop.GetValue(instance, null);
                if (value != null)
                {
                    value = value.Trim();
                    prop.SetValue(instance, value, null);
                }
            }
            else
            {
                // if we don't have a string property we recurse
                TrimObjectValues(prop.GetValue(instance, null));
            }
        }
    }
