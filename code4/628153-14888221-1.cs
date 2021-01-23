    public void AssignListProperty(Object obj, String propName)
    {
      var prop = obj.GetType().GetProperty(propName);
      var listType = typeof(List<>);
      var genericArgs = prop.PropertyType.GetGenericArguments();
      var concreteType = listType.MakeGenericType(genericArgs);
      var newList = Activator.CreateInstance(concreteType);
      prop.SetValue(obj, newList);
    }
