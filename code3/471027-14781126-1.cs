    public class MyFilterProvider : IFilterProvider
    {
        private IWindsorContainer _container;
        public MyFilterProvider(IWindsorContainer container)
        {
            Contract.Requires(container != null);
            _container = container;
        }
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            Type controllerType = controllerContext.Controller.GetType();
            var authorizationProvider = _container.Resolve<IAuthorizationProvider>();
            foreach (FilterAttribute attribute in controllerType.GetCustomAttributes(typeof(FilterAttribute), false))
            {
                object instance = Resolve(attribute);
                yield return new Filter(instance, FilterScope.Controller, 0);
            }
            foreach (FilterAttribute attribute in actionDescriptor.GetCustomAttributes(typeof(FilterAttribute), false))
            {
                object instance = Resolve(attribute);
                yield return new Filter(instance, FilterScope.Action, 0);
            }
        }
        private object Resolve(Attribute attribute)
        {
            IFilterInstanceFactory[] factories = _container.ResolveAll<IFilterInstanceFactory>();
            foreach (IFilterInstanceFactory factory in factories)
            {
                object dependencyInjectedInstance = factory.Create(attribute);
                if (dependencyInjectedInstance != null)
                {
                    return dependencyInjectedInstance;
                }
            }
            return attribute;
        }
    }
