    protected override void Configure()
    {
         _container = new ApplicationContainer();
         _container.AddFacility<TypedFactoryFacility>();
         _container.Register(AllTypes.FromAssembly(typeof(MainViewModel).Assembly)
             .Where(x => x.Name.EndsWith("ViewModel") || x.Name.EndsWith("View"))
             .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
    }
