    public static bool CallsOtherConstructor( this ConstructorInfo source )
    {
    	MethodBody body = source.GetMethodBody();
    	if ( body == null )
    	{
    		throw new ArgumentException( "Constructors are expected to always contain byte code." );
    	}
    
    	// Constructors at the end of the invocation chain start with 'call' immediately.
    	byte[] msil = body.GetILAsByteArray();
    	return !(msil[ 0 ] == OpCodes.Ldarg_0.Value && msil[ 1 ] == OpCodes.Call.Value);
    }
