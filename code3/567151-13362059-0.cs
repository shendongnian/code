    public class InjectibleFilterProvider : FilterAttributeFilterProvider
    {
        private IUnityContainer cont;
        public InjectibleFilterProvider(IUnityContainer container)
        {
            this.cont = container;
        }
        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext,
                  ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    cont.BuildUp(filter.Instance.GetType(), filter.Instance);
                }
                return filters;
            }
            return default(IEnumerable<Filter>);
        }
    }
