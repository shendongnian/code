    private static void FindManagers<Q,T>( ) {
        var IObjectManagerType = typeof( IObjectManager );
    
        var managers = IObjectManagerType.Assembly
              .GetTypes( )
              .Where( t => !t.IsAbstract && t.GetInterfaces().Any( i => i == IObjectManagerType) );
         
        foreach (var manager in managers) {
             var concreteType = manager.MakeGenericType(typeof(Q), typeof(T));
             var fi = concreteType.GetField( "Instance" );
             var instance = fi.GetValue( null );                
        }
    }
