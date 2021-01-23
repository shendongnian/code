    internal sealed class SimpleInjectorFilterAttributeFilterProvider
        : FilterAttributeFilterProvider
    {
        private readonly ConcurrentDictionary<Type, Registration> registrations =
            new ConcurrentDictionary<Type, Registration>();
        private readonly Func<Type, Registration> registrationFactory;
        
        public SimpleInjectorFilterAttributeFilterProvider(Container container)
            : base(false)
        {
            this.registrationFactory = type => 
                Lifestyle.Transient.CreateRegistration(type, container);
        }
        public override IEnumerable<Filter> GetFilters(
            ControllerContext context,
            ActionDescriptor descriptor)
        {
            var filters = base.GetFilters(context, descriptor).ToArray();
            
            foreach (var filter in filters) {
            {
                object instance = filter.Instance;
            
                var registration = registrations.GetOrAdd(
                    instance.GetType(), this.registrationFactory);
                registration.InitializeInstance(instance);                
            }
            return filters;
        }
    }
