    container.RegisterType<IEFContext, LTE_DownFromWeb_EFContext>("Source");
    container.RegisterType<IEFContext, LTE_Licensing_EFContext>("Destination");
    container.RegisterType<IRepositorySession>("Source",new InjectionConstructor(new ResolvedParameter<IEFContext>("Source));
    container.RegisterType<IRepositorySession>("Destination",new InjectionConstructor(new ResolvedParameter<IEFContext>("Destination")));
    container.RegisterType<IDataCopier,ScheduleDataCopier>("0",new InjectionConstructor(new[] {new ResolvedParameter<IRepositorySession("Source"),new ResolvedParameter<IRepositorySesison>("Destination")}));
    //Now resolve
    
    ERunOptions dataCopierType = ExtractParams(args);
    IDataCopier dataCopier = container.Resolve<IDataCopier(dataCopierType.ToString());
    dataCopier.DetectChanges();
    dataCopier.ParseData();
    dataCopier.CopyData();
