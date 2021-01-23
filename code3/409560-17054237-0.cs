    public T[] ResolveAllWithParameters<T>(IEnumerable<Parameter> parameters)
    {
        return Container.Resolve<IEnumerable<T>>(parameters).ToArray();
    }
      
