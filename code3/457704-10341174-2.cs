    private void RegisterViewModels()
    {
        Register(AllTypes.FromAssembly(GetType().Assembly)
                        .Where(x => x.Name.EndsWith("ViewModel"))
                        .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
    }
