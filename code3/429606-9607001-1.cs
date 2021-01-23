    private static DynamicMethod CreateChangeTrackingReaderIL( Type type, Type[] types )
    {
        var method = new DynamicMethod( string.Empty, typeof( string ), new[] { type } );
        ILGenerator il = method.GetILGenerator();
        LocalBuilder lbInstance = il.DeclareLocal( type );
        // place the input parameter of the function onto the evaluation stack
        il.Emit( OpCodes.Ldarg_0 ); 
        // store the input value
        il.Emit( OpCodes.Stloc, lbInstance ); 
        // declare a StringBuilder
        il.Emit( OpCodes.Newobj, typeof( StringBuilder ).GetConstructor( Type.EmptyTypes ) ); 
        foreach( Type t in types )
        {
            // any logic to retrieve properties can go here...
            List<PropertyInfo> properties = __Properties.GetTrackableProperties( t );
            foreach( PropertyInfo pi in properties )
            {
                MethodInfo mi = pi.GetGetMethod();
                if( null == mi )
                {
                    continue;
                }
                il.Emit( OpCodes.Ldloc, lbInstance ); // bring the stored reference onto the eval stack
                il.Emit( OpCodes.Callvirt, mi ); // call the appropriate getter method
                if( pi.PropertyType.IsValueType )
                {
                    il.Emit( OpCodes.Box, pi.PropertyType ); // box the return value if necessary
                }
                // append it to the StringBuilder
                il.Emit( OpCodes.Callvirt, typeof( StringBuilder ).GetMethod( "Append", new Type[] { typeof( object ) } ) ); 
            }
        }
        // call ToString() on the StringBuilder
        il.Emit( OpCodes.Callvirt, typeof( StringBuilder ).GetMethod( "ToString", Type.EmptyTypes ) ); 
        // return the last value on the eval stack (output of ToString())
        il.Emit( OpCodes.Ret ); 
        return method;
    }
