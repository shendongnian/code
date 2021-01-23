    var implementations = new List<Type>();
    foreach (Assembly assembly in <collection of assemblies you want to scan>)
    {
      foreach (Type type in assembly.GetTypes())
      {
        if (type.GetInterfaces().Contains(typeof(IAnimal)))
        {
          implementations.Add(type);
        }
      }
    }
