    public class MainViewModel
    {
	//...
    }
    public class ApplicationBootstrapper : Bootstrapper<MainViewModel>
    {
	    private Container container;
	
	    protected override void Configure()
	    {
		    container = new Container();
		
		    container.Register<IWindowManager, WindowManager>();
          //for Unity, that would probably be something like:
          //container.RegisterType<IWindowManager, WindowManager>();
    		container.RegisterSingle<IEventAggregator, EventAggregator>();
		
		    container.Verify();
	    }
	
	    protected override object GetInstance(string key, Type service)
	    {
		    // Now, for example, you can't resolve dependency by key in SimpleInjector, so you have to
		    // create the type out of the string (if the 'service' parameter is missing)
		    var serviceType = service;
		    if(serviceType == null)
		    {
			    var typeName = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.Name == key).Select(x => x.FullName).FirstOrDefault();
			    if(typeName == null)
				    throw new InvalidOperationException("No matching type found");
			
			    serviceType = Type.GetType(typeName);
		    }
		
		    return container.GetInstance(serviceType);
            //Unity: container.Resolve(serviceType) or Resolve(serviceType, name)...?
                    
	    }
	
	    protected override IEnumerable<object> GetAllInstances(Type service)
	    {
		    return container.GetAllInstances(service);
            //Unity: No idea here.
	    }
	
	    protected override void BuildUp(object instance)
	    {
		    container.InjectProperties(instance);
            //Unity: No idea here.
	    }
    }
