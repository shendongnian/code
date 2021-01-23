    foreach (var t in GetLoadableTypes(assembly)) 
    { 
      if (t.IsInterface) continue; 
      if (t.IsAbstract) continue; 
      if (t.IsNotPublic) continue; 
      if (!typeof(IGeometryServices).IsAssignableFrom(t)) continue; 
