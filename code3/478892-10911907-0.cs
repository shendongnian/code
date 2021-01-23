      Assembly asm = Assembly.GetExecutingAssembly();
      List<string> namespaceList = new List<string>();
      List<string> returnList = new List<string>();
      foreach (Type type in asm.GetTypes())
    {
        if (type.Namespace == nameSpace)
            namespaceList.Add(type.Name);
    }
        foreach (String className in namespaceList)
        returnList.Add(className);
        return returnList;
  
