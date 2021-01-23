    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HubConfiguration()
            {
                Resolver = new SignalRSimpleInjectorDependencyResolver(Container)
            };
            app.MapSignalR(config);
        }
    }
	public class SignalRSimpleInjectorDependencyResolver : DefaultDependencyResolver
	{
		private readonly Container _container;
		public SignalRSimpleInjectorDependencyResolver(Container container)
		{
			_container = container;
		}
		public override object GetService(Type serviceType)
		{
			return ((IServiceProvider)_container).GetService(serviceType)
				   ?? base.GetService(serviceType);
		}
		public override IEnumerable<object> GetServices(Type serviceType)
		{
			return _container.GetAllInstances(serviceType)
				.Concat(base.GetServices(serviceType));
		}
	}
