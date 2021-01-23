      Assembly a = Assembly.LoadFile("Insert File Path");
      var typesWithMethods = a.GetTypes().Select(x => x.GetMethods(BindingFlags.Public).Where(y => y.ReturnType.Name != "Void" &&
                                                        y.Name != "ToString" &&
                                                        y.Name != "Equals" &&
                                                        y.Name != "GetHashCode" &&
                                                        y.Name != "GetType"));
      foreach (var assemblyType in typesWithMethods)
      {
        foreach (var function in assemblyType)
        {
          //do stuff with method
        }
      }
