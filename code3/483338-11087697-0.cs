    public ViewPersonViewModel(IPerson person)
        this(DependencyResolver.GetInstance<IDataAccessService>(), person)
    {
    }
    public ViewPersonViewModel(
        IDataAccessService dataService, IPerson person)
    {
        _dataService= dataService;
        _person = person;
    }
