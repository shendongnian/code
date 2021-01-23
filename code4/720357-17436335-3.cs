    public class FilterResolvingActionInvoker : ControllerActionInvoker
    {
        protected IEnumerable<IFilterProvider> Providers { get; private set; }
        // Filters registered with the container are injected by the container
        public FilterResolvingActionInvoker(IEnumerable<IFilterProvider> providers)
        {
            this.Providers = providers;
        }
        // Add the filter to the current FilterInfo
        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            foreach (var provider in this.Providers)
            {
                provider.AddFilters(filters);
            }
            return filters;
        }
    }
