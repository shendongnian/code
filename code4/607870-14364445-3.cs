    public class ExtendedLoggingFacility : LoggingFacility
    {
        public ExtendedLoggingFacility()
            : base()
        {
        }
        public ExtendedLoggingFacility(LoggerImplementation loggingApi) :
            base(loggingApi)
        {
        }
        public ExtendedLoggingFacility(LoggerImplementation loggingApi, string configFile) :
            base(loggingApi, configFile)
        {
        }
        public ExtendedLoggingFacility(string customLoggerFactory, string configFile) :
            base(customLoggerFactory, configFile)
        {
        }
        public ExtendedLoggingFacility(LoggerImplementation loggingApi, string customLoggerFactory, string configFile) :
            base(loggingApi, customLoggerFactory, configFile)
        {
        }
        protected override void Init()
        {
            base.Init();
            Kernel.Register(Component.For<AspectLogger>());
            Kernel.ComponentModelBuilder.AddContributor(new AddLoggingAspect());
        }
    }
    public class AddLoggingAspect : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (
                !(model.Implementation.GetProperties()
                       .Any(prop => prop.PropertyType.GetInterfaces().Contains(typeof(ILogger))) ||
                  model.Implementation.GetFields()
                       .Any(l => l.FieldType.GetInterfaces().Contains(typeof(ILogger)))))
            {
                model.Interceptors.AddIfNotInCollection(InterceptorReference.ForType<AspectLogger>());
            }
        }
    }
