    var objectSet = entities.GetType( ).GetProperties( )
        .Where( p => p.PropertyType.IsGenericType 
             && p.PropertyType.GetGenericArguments( )[ 0 ].Name == typeof( T ).Name )
        .Select( p => p.GetValue( entities, null ) as ObjectSet<T> )
        .First( );
    return objectSet.ToList( );
