	using System.ComponentModel.Composition.Hosting;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using MefContrib.Hosting.Conventions;
	using MefContrib.Web.Mvc;
	[assembly: PreApplicationStartMethod( typeof(Core.Web.Initialization.DependencyInjection.RegisterDependencyResolver), "RegisterHttpModule" )]
	namespace Core.Web.Initialization.DependencyInjection
	{
		public class RegisterDependencyResolver
		{
			public static void RegisterHttpModule()
			{
				// Register the CompositionContainerLifetimeHttpModule HttpModule.
				// This makes sure everything is cleaned up correctly after each request.
				CompositionContainerLifetimeHttpModule.Register();		
			}
			public void Configure()
			{
				// Create MEF catalog based on the contents of ~/bin.
				//
				// Note that any class in the referenced assemblies implementing in "IController"
				// is automatically exported to MEF. There is no need for explicit [Export] attributes
				// on ASP.NET MVC controllers. When implementing multiple constructors ensure that
				// there is one constructor marked with the [ImportingConstructor] attribute.
				var catalog = new AggregateCatalog(
					new DirectoryCatalog( "bin" ),
					new ConventionCatalog( new MvcApplicationRegistry() ) );
				// Tell MVC3 to use MEF as its dependency resolver.
				var dependencyResolver = new CompositionDependencyResolver( catalog );
				DependencyResolver.SetResolver( dependencyResolver );
				// Tell MVC3 to resolve dependencies in controllers
				ControllerBuilder.Current.SetControllerFactory( new DefaultControllerFactory( new CompositionControllerActivator( dependencyResolver ) ) );
				// Tell MVC3 to resolve dependencies in filters
				FilterProviders.Providers.Remove( FilterProviders.Providers.Single( f => f is FilterAttributeFilterProvider ) );
				FilterProviders.Providers.Add( new CompositionFilterAttributeFilterProvider( dependencyResolver ) );
				// Tell MVC3 to resolve dependencies in model validators
				ModelValidatorProviders.Providers.Remove( ModelValidatorProviders.Providers.OfType<DataAnnotationsModelValidatorProvider>().Single() );
				ModelValidatorProviders.Providers.Add( new CompositionDataAnnotationsModelValidatorProvider( dependencyResolver ) );
				// Tell MVC3 to resolve model binders through MEF. Model binders must be decorated with [ModelBinderExport].
				ModelBinderProviders.BinderProviders.Add( new CompositionModelBinderProvider( dependencyResolver ) );
			}
		}
	}
