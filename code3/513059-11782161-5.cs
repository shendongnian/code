    public class NinjectFilterProvider : FilterAttributeFilterProvider
    {
        private readonly IKernel _kernel;
        public NinjectFilterProvider(IKernel kernel)
        {
            _kernel = kernel;
        }
        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            foreach (var filter in filters)
            {
                
                _kernel.Inject(filter.Instance);
            }
            return filters;
        }
    }
