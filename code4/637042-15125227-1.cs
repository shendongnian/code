    public class SimpleInjectorPresenterFactory 
        : IPresenterFactory
    {
        private readonly Container _container;
        private ThreadLocal<IView> _currentView = 
            new ThreadLocal<IView>();
        public SimpleInjectorPresenterFactory(
            Container container)
        {
            _container = container;
            _container.ResolveUnregisteredType += (s, e) => 
            {
                if (typeof(IView).IsAssignableFrom(
                    e.UnregisteredServiceType))
                {
                    e.Register(() => _currentView);
                }
            };
        }
        public IPresenter Create(Type presenterType, 
            Type viewType, IView viewInstance)
        {
            _currentView.Value = viewInstance;
            return _container.GetInstance(presenterType) 
                as IPresenter;
        }
    }
