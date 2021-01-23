    static bool Implements_IFoo(Type type)
    {
      if (typeof(IFoo).IsAssignableFrom(type.BaseType))
        return false;
      var barInterfaces = type.GetInterfaces()
        .Where(iface => typeof(IFoo).IsAssignableFrom(iface))
        .ToArray();
      return barInterfaces.Length > 0 
         && barInterfaces.Length == barInterfaces.Count(iface => iface == typeof(IFoo));
    }
    static bool Implements_IFoo_Optimized(Type type)
    {
      if (typeof(IFoo).IsAssignableFrom(type.BaseType))
        return false;
      return type.GetInterfaces()
        .Where(iface => typeof(IFoo).IsAssignableFrom(iface))
        .Count() == 1;
    }
