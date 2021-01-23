    public static void ObjectToObject(object source, object destination)
    {
      // Purpose : Use reflection to set property values of objects that share the same property names.
      Type s = source.GetType();
      Type d = destination.GetType();
      const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
      var objSourceProperties = s.GetProperties(flags);
      var objDestinationProperties = d.GetProperties(flags);
      var propertyNames = objSourceProperties
      .Select(c => c.Name)
      .ToList();
      foreach (var properties in objDestinationProperties.Where(properties => propertyNames.Contains(properties.Name)))
      {
        try
        {
          PropertyInfo piSource = source.GetType().GetProperty(properties.Name);
          properties.SetValue(destination, piSource.GetValue(source, null), null);
        }
        catch (Exception ex)
        {
          throw;
        }
      }
    }
    public static List<T> CopyList<T>(this List<T> lst)
    {
      List<T> lstCopy = new List<T>();
      foreach (var item in lst)
      {
        var instanceOfT = Activator.CreateInstance<T>();
        ObjectToObject(item, instanceOfT);
        lstCopy.Add(instanceOfT);
      }
      return lstCopy;
    }
