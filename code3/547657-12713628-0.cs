    public bool IsInMemory(string propertyName, object value)
    {
        PropertyInfo property = typeof(T).GetProperty(propertyName);
        if(property == null) throw new ArgumentException("Invalid property name: " + propertyName);
        
        var predicate = new Func<T, bool>(item => object.Equals(value, property.GetValue(item, null)));
        return IsInMemory(predicate);
    }
