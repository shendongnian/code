    var container = new UnityContainer();
    container.RegisterType<ISessionManager, DefaultSessionManager>()
      .RegisterType<ISessionManager, OnCallSessionManager>("oncall")
      .RegisterType<CustomerService>()
      .RegisterType<CustomerService>(
        "oncall",
        new InjectionConstructor(
          new ResolvedParameter(
            typeof(ISessionManager),
            "oncall")))
      .RegisterType<ViewModel>()
      .RegisterType<DataManager>(
        new InjectionConstructor(
          new ResolvedParameter(
            typeof(CustomerService),
            "oncall")));
