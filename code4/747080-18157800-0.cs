    private static void FindManagers()
    {
      Type type = typeof(IObjectManager);
      IEnumerable<Type> managers = type.Assembly
                       .GetTypes()
                       .Where(t => !t.IsAbstract && t.GetInterfaces().Contains(type));
      foreach (Type manager in managers)
      {
        var fi = manager.GetField("Instance", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        if (!fi.FieldType.IsGenericParameter)
        {
          var x = fi.GetValue(null); // NullPointerException because we gave it null
                                     // but you will not encounter the late bound error thingy
        }
      }
    }
