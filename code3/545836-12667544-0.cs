    private static void GetProps(Type T, List<PropertyInfo> Properties)
    {
      if (T != typeof(Base))
      {
        var pis = T.GetProperties();
        foreach (var pi in pis)
        {
          if (pi.DeclaringType == T && pi.GetCustomAttribute<IgnoreForAllAttribute>() == null)
          {
            Properties.Add(pi);
          }
        }
        GetProps(T.BaseType, Properties);
      }
    }
