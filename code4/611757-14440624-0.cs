    public List<Type> TypesWithAttributeDefined(Type attribute)
    {
      List<Type> types = assembly.GetTypes();
      return types.Where(t => Attribute.IsDefined(t, attribute)).ToList();
    }
