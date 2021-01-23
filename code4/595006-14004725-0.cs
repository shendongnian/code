    public void Initialize()
    {
        ISomeDataService service = DataService;
        service.Connect();
        _container.RegisterInstance<ISomeDataService>(service);
    }
    internal ISomeDataService DataService
    {
      get { return _service ?? _service = _container.Resolve<SomeDataService>(); }
      set { _service = value;}
    }
