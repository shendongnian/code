        var container = new UnityContainer();
        container.RegisterInstance(typeof (ILogger), new Logger());
        container.Configure(x => 
            {
                x.AfterBuildingUp<IFetchDataCommand>().Call((c,s) => s.Logger = c.Resolve<ILogger>());
                x.Scan(
                    scan =>
                        {
                            scan.Assembly(Assembly.GetExecutingAssembly());
                            scan.InternalTypes();
                            scan.With<AddAllConvention>().TypesImplementing<IFetchDataCommand>();
                            scan.WithSetAllPropertiesConvention().OfType<ILogger>();
                        });
            });
        var dataCommand = container.ResolveAll<IFetchDataCommand>().ToArray();
        Assert.That(dataCommand[0].Logger, Is.Not.Null);
        Assert.That(dataCommand[1].Logger, Is.Not.Null);
