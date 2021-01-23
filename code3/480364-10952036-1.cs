    public class AppSettingsAttribute: Attribute {}
    [AppSettings]
    public class Settings
    {
        public bool Sliding { get; set; }
        public TimeSpan CacheDuration { get; set; }
    }
    public class MyComponent
    {
        private readonly Settings settings;
        public Settings Settings { get { return settings; } }
        public MyComponent(Settings settings)
        {
            this.settings = settings;
        }
    }
    public class AppSettingsResolver : ISubDependencyResolver
    {
        private readonly IKernel kernel;
        public AppSettingsResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            var settings = Activator.CreateInstance(dependency.TargetType);
            var converter = (IConversionManager) kernel.GetSubSystem(SubSystemConstants.ConversionManagerKey);
            foreach (var property in dependency.TargetType.GetProperties())
            {
                var v = ConfigurationManager.AppSettings[property.Name];
                var convertedValue = converter.PerformConversion(v, property.PropertyType);
                property.SetValue(settings, convertedValue, null);
            }
            return settings;
        }
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            return dependency.TargetType.IsDefined(typeof(AppSettingsAttribute), true);
        }
    }
