    static void Update<T>(T original, T updated) where T : class
    {
        var Properties = typeof(T).GetProperties();
        foreach (PropertyInfo property in Properties)
        {
            var oldval = property.GetValue(original, null);
            var newval = property.GetValue(updated, null);
            if (oldval != newval) property.SetValue(original, newval, null);
        }
    }
