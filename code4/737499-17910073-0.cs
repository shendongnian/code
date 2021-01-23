    internal sealed class SimpleInjectorFilterAttributeFilterProvider
        : FilterAttributeFilterProvider
    {
        private readonly Container container;
        public SimpleInjectorFilterAttributeFilterProvider(Container container)
            : base(false)
        {
            this.container = container;
        }
        public override IEnumerable<Filter> GetFilters(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext,
                actionDescriptor).ToArray();
            for (int index = 0; index < filters.Length; index++)
            {
                var filter = filters[index];
                this.InitializeInstance(filter.Instance);
            }
            return filters;
        }
        private void InitializeInstance(object instance)
        {
            var producer = container.GetRegistration(instance.GetType(), true);
            var registration = producer.Registration;
            registration.InitializeInstance(instance);
        }
    }
