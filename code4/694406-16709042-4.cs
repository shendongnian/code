    public class MyFilterProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            if (actionDescriptor.GetCustomAttributes(typeof(MyAuthorizeAttribute), true).Any())
            {
                var filter = DependencyResolver.Current.GetService<MyAuthorizationFilter>();
                yield return new Filter(filter, FilterScope.Global);
            }
    
            yield break;
        }
    }
