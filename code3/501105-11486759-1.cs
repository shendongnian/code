    // inside your container builder:
    if (InformationRetreiver.IsAvailable())
        builder.RegisterType<InformationRetriever>()
               .As<IInformationRetriever>()
    // inside InformationService, make the dependency optional
    public InformationService(IInformationRetriever informationRetriever = null)
    {
        _informationRetriever = informationRetriever;
    }
