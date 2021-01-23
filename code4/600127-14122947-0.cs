    public List<ConstructorInfo> GetConstructors(Type type, Type baseParameterType)
    {
      List<ConstructorInfo> result = new List<ConstructorInfo>();
      foreach (ConstructorInfo ci in type.GetConstructors())
      {
        var parameters = ci.GetParameters();
        if (parameters.Length != 1)
          continue;
        ParameterInfo pi = parameters.First();
        if (!baseParameterType.IsAssignableFrom(pi.ParameterType))
          continue;
        result.Add(ci);
      }
      return result;
    }
