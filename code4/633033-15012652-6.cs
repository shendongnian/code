    private T CreateWithValues<T>(DbPropertyValues values)
        where T : new()
    {
        T entity = new T();
        Type type = typeof(T);
    
        foreach (var name in values.PropertyNames)
        {
            var property = type.GetProperty(name);
            property.SetValue(entity, values.GetValue<object>(name));
        }
    
        return entity;
    }
