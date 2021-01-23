    public class IocResolver : MarkupExtension
    {
        public IocResolver()
        { }
        public IocResolver(string namedInstance)
        {
            NamedInstance = namedInstance;
        }
        [ConstructorArgument("namedInstance")]
        public string NamedInstance { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider
                .GetService(typeof(IProvideValueTarget));
            // Find the type of the property we are resolving
            var targetProperty = provideValueTarget.TargetProperty as PropertyInfo;
            if (targetProperty == null)
                throw new InvalidProgramException();
            Debug.Assert(Resolve != null, "Resolve must not be null. Please initialize resolving method during application startup.");
            Debug.Assert(ResolveNamed != null, "Resolve must not be null. Please initialize resolving method during application startup.");
            // Find the implementation of the type in the container
            return NamedInstance == null
                ? (Resolve != null ? Resolve(targetProperty.PropertyType) : DependencyProperty.UnsetValue)
                : (ResolveNamed != null ? ResolveNamed(targetProperty.PropertyType, NamedInstance) : DependencyProperty.UnsetValue);
        }
        public static Func<Type, object> Resolve { get; set; }
        public static Func<Type, string, object> ResolveNamed { get; set; }
    }
