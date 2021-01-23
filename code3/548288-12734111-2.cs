    public object FooEventHandler(object obj)
    {
      if (obj == null)
        return null;
    
      var property = obj.GetType().GetProperty("MyProperty");
      if (property != null && property.PropertyType == typeof(string) && property.GetSetMethod(true) != null)
      {
        property.SetValue(obj, "updated", new object[]{ });
        return obj;
      }
    
      return null;
    }
