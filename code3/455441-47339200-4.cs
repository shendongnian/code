    public class FactoryModule: NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromThisAssembly()
                                .IncludingNonPublicTypes()
                                .SelectAllClasses()
                                .InNamespaceOf<FactoryModule>()
                                .BindAllInterfaces()
                                .Configure(b => b.InSingletonScope()));
        }
    }
