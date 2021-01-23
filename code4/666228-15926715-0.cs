    public class MessageEndpoint : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
    	public void Init()
    	{
    		var container = new WindsorContainer();
    		var installerFactory = new MyInstallerFactory();
    		container.Install(FromAssembly.This(installerFactory));
    
    		var logger = container.Resolve<ILogger>();
    		logger.Debug("Container bootstrapped");
    
    		Configure.With()
    				 .DisableTimeoutManager()
    				 .CastleWindsorBuilder(container)
    				 .JsonSerializer();
    
    		logger.Debug("Bus configured");
    	}
    }
