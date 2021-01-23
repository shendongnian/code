    static IEnumerable<PropertyInfo> GetMappedProperties(Type type)
    {
      return type
        .GetProperties()
        .Select(p => GetMappedProperty(type, p.Name))
        .Where(p => p != null);
    }
    static PropertyInfo GetMappedProperty(Type type, string name)
    {
      if (type == null)
        return null;
      var prop = type.GetProperty(name);
      if (prop.DeclaringType == type)
        return prop;
      else
        return GetMappedProperty(type.BaseType, name);
    }
