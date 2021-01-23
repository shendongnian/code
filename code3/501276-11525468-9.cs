    public void CreateComponent(string name, string compType)
    {
        var matchingFactory = FooFactories.FirstOrDefault(
            x => x.Metadata.CompType == compType);
        if (matchingFactory == null)
        {
            throw new ArgumentException(
                string.Format("'{0}' is not a known compType", compType),
                "compType");
        }
        else
        {
            IFoo foo = matchingFactory.CreateExport().Value;
            foo.Name = name;
            return foo;
        }
    }
