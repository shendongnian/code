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
            Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
        }
        private void Kernel_ComponentModelCreated(ComponentModel model)
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
