    public static string GetNameFrom( object myObject )
    {
        var t = myObject.GetType();
        if( t == typeof(Country) )
        {
            return ((Country)myObject).City.Name;
        }
        
        return ((City)myObject).Name;
    }
