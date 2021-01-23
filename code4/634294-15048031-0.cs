    public class FilterProvider
        : IFilterProvider
    {
        #region IFilterProvider Members
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor);
        }
        #endregion
    }
