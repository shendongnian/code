    private static readonly Dictionary<string, Func<XElement, Animal>> Factories =
        new Dictionary<string, Func<XElement, Animal>>
    {
        { "Dog", Dog.FromXElement },
        { "Cat", Cat.FromXElement },
        // etc
    }
    ...
    List<Animal> animals = batch.Elements()
                                .Select(x => Factories[x.Name.LocalName](x))
                                .ToList();
