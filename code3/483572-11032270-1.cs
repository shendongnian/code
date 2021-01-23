    ConfigurationBuilder builder = new ConfigurationBuilder();
    builder.Scan(s =>
    {
      s.AssembliesFromApplicationBaseDirectory();
      s.With(new ImplementsIInterfaceNameConvention());
    }
    var container = new UnityContainer();
    container.AddExtension(builder);
    container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    var serviceLocator = new UnityServiceLocator(container);
    ServiceLocator.SetLocatorProvider(() => serviceLocator);
