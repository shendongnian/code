    public static class AutoFixtureOpenGenericsExtensions
    {
    	public static void RegisterOpenGenericImplementation( this IFixture that, Type serviceType, Type componentType )
    	{
    		if ( !serviceType.ContainsGenericParameters )
    			throw new ArgumentException( "must be open generic", "serviceType" );
    		if ( !componentType.ContainsGenericParameters )
    			throw new ArgumentException( "must be open generic", "componentType" );
    		// TODO verify number of type parameters is 1 in each case
    		that.Customize( new OpenGenericsBinderCustomization( serviceType, componentType ) );
    	}
    
    	public class OpenGenericsBinderCustomization : ICustomization
    	{
    		readonly Type _serviceType;
    		readonly Type _componentType;
    
    		public OpenGenericsBinderCustomization( Type serviceType, Type componentType )
    		{
    			_serviceType = serviceType;
    			_componentType = componentType;
    		}
    
    		void ICustomization.Customize( IFixture fixture )
    		{
    			fixture.Customizations.Add( new OpenGenericsSpecimenBuilder( _serviceType, _componentType ) );
    		}
    
    		class OpenGenericsSpecimenBuilder : ISpecimenBuilder
    		{
    			readonly Type _serviceType;
    			readonly Type _componentType;
    
    			public OpenGenericsSpecimenBuilder( Type serviceType, Type componentType )
    			{
    				_serviceType = serviceType;
    				_componentType = componentType;
    			}
    
    			object ISpecimenBuilder.Create( object request, ISpecimenContext context )
    			{
    				var typedRequest = request as Type;
    				if ( typedRequest != null && typedRequest.IsGenericType && typedRequest.GetGenericTypeDefinition() == _serviceType )
    					return context.Resolve( _componentType.MakeGenericType( typedRequest.GetGenericArguments().Single() ) );
    				return new NoSpecimen( request );
    			}
    		}
    	}
    }
