    public class Bootstrapper : Bootstrapper<MainViewModel>
    	{
    
    		private readonly SimpleContainer _container = new SimpleContainer();
    
    		protected override void Configure()
    		{
    			_container.Instance<IWindowManager>(new WindowManager());
    			_container.Singleton<IEventAggregator, EventAggregator>();
    			_container.PerRequest<MainViewModel>();
    		}
    
    		protected override object GetInstance(Type service, string key)
    		{
    			return _container.GetInstance(service, key);
    		}
    
    		protected override IEnumerable<object> GetAllInstances(Type service)
    		{
    			return _container.GetAllInstances(service);
    		}
    
    		protected override void BuildUp(object instance)
    		{
    			_container.BuildUp(instance);
    		}
    
    	}
