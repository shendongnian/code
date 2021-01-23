    public class AppSettingsAttribute: Attribute {}
    public class AppSettingsResolver : ISubDependencyResolver
    {
	private readonly IKernel kernel;
	public AppSettingsResolver(IKernel kernel)
	{
	    this.kernel = kernel;
	}
	public object Resolve( CreationContext context, ISubDependencyResolver contextHandlerResolver, Castle.Core.ComponentModel model, DependencyModel dependency )
	{
	    if( (
			from constructor in model.Constructors
			from dependencyModel in constructor.Dependencies
			where dependencyModel == dependency
				
			from parameterInfo in constructor.Constructor.GetParameters()
			select parameterInfo ).Any( parameterInfo => parameterInfo.Name == dependency.DependencyKey ) )
	    {
	    	var converter = (IConversionManager) kernel.GetSubSystem(SubSystemConstants.ConversionManagerKey);
	    	return converter.PerformConversion(ConfigurationManager.AppSettings[dependency.DependencyKey], dependency.TargetType);
	    }
	    return null;
	}
	public bool CanResolve( CreationContext context, ISubDependencyResolver contextHandlerResolver, Castle.Core.ComponentModel model, DependencyModel dependency )
	{
	    return (
			from constructor in model.Constructors
			from dependencyModel in constructor.Dependencies
			where dependencyModel == dependency
				
			from parameterInfo in constructor.Constructor.GetParameters()
			where parameterInfo.Name == dependency.DependencyKey
			select ( Attribute.GetCustomAttribute( parameterInfo, typeof(AppSettingsAttribute) ) != null ) 
		).FirstOrDefault();
	}
    }
    [ TestFixture ]
    public class When_resolving_dependancies_from_the_app_settings_configuration_section
    {
    	[ Test ]
    	public void Should_resolve_a_string_and_an_int()
    	{
    		var container = new WindsorContainer();
    
    		container.Kernel.Resolver.AddSubResolver(new AppSettingsResolver( container.Kernel ));
    		container.Register( Component.For<Dependent>() );
    
    		var dependent = container.Resolve<Dependent>();
    
    		dependent.Foo.Should().Be( "bar" );
    
    		dependent.Baz.Should().Be( 1 );
    	}
    
    	public class Dependent
    	{
    		public string Foo { get; private set; }
    		public int Baz { get; private set; }
    
    		public Dependent([AppSettings]string foo, [AppSettings]int baz)
    		{
    			Foo = foo;
    			Baz = baz;
    		}
    	}
    }
