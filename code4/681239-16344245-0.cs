    public T2 GetGeneratedType<T1, T2>(string name) where T1 : class where T2 : class
    {
      var type = typeof(T1);
      var generatedName = type.AssemblyQualifiedName.Replace(type.Name, name);
      return (T2)Activator.CreateInstance(Type.GetType(generatedName));
    }
