    static string GetNameFrom( object myObject )
    {
        var type = myObject.GetType();
        var city = myObject.GetProperty( "City" );
        if( city != null)
        {
            var cityVal = city.GetValue( myObject, null );
            return (string)cityVal.GetType().GetProperty( "Name" ).GetValue( cityVal, null );
        }
        
        return (string)type.GetProperty( "Name" ).GetValue( myObject, null );
    }
