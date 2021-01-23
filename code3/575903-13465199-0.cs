    public class PluginManager:IDisposable
	{
		IKernel kernel;
		public PluginManager()
		{
			kernel = new StandardKernel();
			kernel.Bind(
				   x => x.FromThisAssembly()
						 .SelectAllClasses().InheritedFrom<IPlugin>()
						 .BindAllInterfaces()
						 .Configure(c =>c.InSingletonScope()));
			
		}
		public T GetPluginInstance<T>()
		{
			return kernel.Get<T>();
		}
		public IEnumerable<T> GetPluginInstances<T>()
		{
			return kernel.GetAll<T>();
		}
		public void Dispose()
		{
			kernel.Dispose();
		}
	}
