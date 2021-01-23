    var dummyFactory = new DummyFactory();
    var provider = ServicesFactory.Create(
        defaultServiceProvider => defaultServiceProvider.AddInstance<ITraceOutputFactory>(dummyFactory));
    using (WebApp.Start<Startup>(provider, new StartOptions("http://localhost:8090")))
    {
        Console.ReadLine();
    }
