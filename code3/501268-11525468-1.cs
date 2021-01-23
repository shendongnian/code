    public void CreateComponent(string name)
    {
        var factory = 
            FooFactories.FirstOrDefault(x => x.Metadata.CompType == name);
        if (factory == null)
            throw new InvalidArgumentException(
                string.Format("'{0}' is not a valid component name", name));
        return factory.CreateExport().Value;
    }
