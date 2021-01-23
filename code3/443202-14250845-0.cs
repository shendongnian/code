    public class ConditionalFilterProvider : IFilterProvider
    {
        private readonly
          IEnumerable<Func<ControllerContext, ActionDescriptor, object>> _conditions;
    
        public ConditionalFilterProvider(
          IEnumerable<Func<ControllerContext, ActionDescriptor, object>> conditions)
        {
            _conditions = conditions;
        }
    
        public IEnumerable<Filter> GetFilters(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            return from condition in _conditions
                   select condition(controllerContext, actionDescriptor) into filter
                   where filter != null
                   select new Filter(filter, FilterScope.Global, null);
        }
    }
