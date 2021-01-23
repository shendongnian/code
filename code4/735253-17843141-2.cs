    var list = new List<Lazy<IAnimal, Type>>();
    list.Add(new Lazy<IAnimal, Type>(() => kernel.Get<Dog>(), typeof(Dog)));
    list.Add(new Lazy<IAnimal, Type>(() => kernel.Get<Pussy>(), typeof(Pussy)));
    list.Add(new Lazy<IAnimal, Type>(() => kernel.Get<Horse>(), typeof(Horse)));
    kernel.Bind<List<Lazy<IAnimal, Type>>().ToInstance(list);
