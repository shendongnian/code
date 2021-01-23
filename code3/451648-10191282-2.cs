    [assembly: ExportAssembly]
    namespace This.That
    {
    
    	[Export(typeof(IIocInstaller))]
    	public class IocInstaller : IIocInstaller
    	{
    		public void Setup(ContainerBuilder builder)
    		{
    			....
    		}
    	}
    }
