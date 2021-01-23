    public static bool CallsOtherConstructor( this ConstructorInfo constructor )
    {
    	MethodBody body = constructor.GetMethodBody();
    	if ( body == null )
    	{
    		throw new ArgumentException( "Constructors are expected to always contain byte code." );
    	}
    
    	// Constructors at the end of the invocation chain start with 'call' immediately.
    	var untilCall = body.GetILAsByteArray().TakeWhile( b => b != OpCodes.Call.Value );
	    return !untilCall.All( b =>
		    b == OpCodes.Nop.Value ||     // Never encountered, but my intuition tells me a no-op would be valid.
		    b == OpCodes.Ldarg_0.Value || // Seems to always precede Call immediately.
		    b == OpCodes.Ldarg_1.Value    // Seems to be added when calling base constructor.
		    );
    }
