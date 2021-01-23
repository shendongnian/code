    public static bool IsEnumerable( object myProperty )
    {
        if( typeof(IEnumerable).IsAssignableFrom(myProperty .GetType())
            || typeof(IEnumerable<>).IsAssignableFrom(myProperty .GetType()))
            return true;
        return false;
    }
    public static string Iterate( object myProperty )
    {
        var ie = myProperty as IEnumerable;
        string s = string.Empty;
        if( null =! ie)
        {
            bool first = true;
            foreach( var p in ie )
            {
                if( !first )
                    s += ", ";
                s += p.ToString();
                first = false;
            }
        }
    }
    foreach( var p in myObject.GetType().GetProperties() )
    {
        var myProperty = p.GetValue( myObject );
        if( IsEnumerable( myProperty ) )
        {
            Iterate( myProperty );
        }
    }
