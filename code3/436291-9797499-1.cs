    // cls is the target type, inf is the interface type
    // you'll need your own CreateProxy
    var declaringTypes = map.TargetMethods.Select(m => m.DeclaringType);
    bool reimpls = declaringTypes.Contains(cls);
    if (reimpls)
      return true;
    var proxyMap = CreateProxy(cls).GetType().GetInterfaceMap(inf);
    for (int i = 0; i < proxyMap.TargetMethods.Length; i++)
    {
      // I could be assuming the methods are in the same order
      // that could be resolved if needed
      if (proxyMap.TargetMethods[i].DeclaringType != 
          map.TargetMethods[i].DeclaringType)
        return false;
    }
    return true;
