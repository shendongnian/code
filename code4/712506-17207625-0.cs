    internal static object CreateInstanceWithParam(Type type, object source)
    {
        object instance = Activator.CreateInstance(type);
        foreach (var sourceProperty in d.GetType()
                                        .GetProperties(BindingFlags.Instance | 
                                                       BindingFlags.Public))
        {
            var targetProperty = type.GetProperty(sourceProperty.Name);
            // TODO: Check that the property is writable, non-static etc
            if (targetProperty != null)
            {
                object value = sourceProperty.GetValue(source);
                targetProperty.SetValue(instance, value);
            }
        }
        return instance;
    }
