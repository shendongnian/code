    public IEnumerable<ConstructorInfo> GetConstructors(Type type, Type baseParameterType)
    {
      type.GetConstructors()
        .Where(ci => ci.GetParameters().Length == 1)
        .Where(ci => baseParameterType.IsAssignableFrom(ci.GetParameters().First().ParameterType)
    }
