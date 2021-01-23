    [AttributeUsage( AttributeTargets.Parameter, AllowMultiple = true )]
    sealed class CustomizeWithAttribute : CustomizeAttribute
    {
    	readonly Type _type;
    
    	public CustomizeWithAttribute( Type customizationType )
    	{
    		if ( customizationType == null )
    			throw new ArgumentNullException( "customizationType" );
    		if ( !typeof( ICustomization ).IsAssignableFrom( customizationType ) )
    			throw new ArgumentException( 
    			    "Type needs to implement ICustomization" );
    		_type = customizationType;
    	}
    
    	public override ICustomization GetCustomization( ParameterInfo parameter )
    	{
    		return (ICustomization)Activator.CreateInstance( _type );
    	}
    }
