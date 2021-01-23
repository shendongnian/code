    var outerProp = f.GetType().GetProperty("A");
    Attribute b = Attribute.GetCustomAttribute(outerProp, typeof(BarAttribute));
    if (b == null)
    {
        var candidates = (from iType in f.GetType().GetInterfaces()
                          let prop = iType.GetProperty("A")
                          where prop != null
                          let map = f.GetType().GetInterfaceMap(iType)
                          let index = Array.IndexOf(map.TargetMethods, outerProp.GetGetMethod())
                          where index >= 0 && map.InterfaceMethods[index] == prop.GetGetMethod()
                          select prop).Distinct().ToArray();
        if (candidates.Length == 1)
        {
            b = Attribute.GetCustomAttribute(candidates[0], typeof(BarAttribute));
        }
    }
