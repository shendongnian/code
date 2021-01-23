    public class AutoScanModule : Module
    {
        private readonly Assembly[] _assembliesToScan;
        public AutoScanModule(params Assembly[] assembliesToScan)
        {
            _assembliesToScan = assembliesToScan;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_assembliesToScan)
                .Where(t => t.GetCustomAttributes(typeof (AutoRegisterAttribute), false).Any())
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
