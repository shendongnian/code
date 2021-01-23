    public IPersonRepository GetPersonRepository()
    {
      return DesignMode
        ? new DesignTimePersonRepository()
        : _container.Resolve<IPersonRepository>();
    }
