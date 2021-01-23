    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IRepositoryNum1>().Use<Num1Repository>();
                            x.For<IRepositoryNum2>().Use<Num2Repository>();
                            x.For<IRepositoryNum3>().Use<Num3Repository>();
                        });
            return ObjectFactory.Container;
        }
    }
