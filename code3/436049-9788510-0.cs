    public static String GetValue( string key, string default )
    {
        if ( Session[ key ] == null ) { return default; }
        return Session[ key ].toString();
    }
    
    string y = GetValue( 'key', 'none' );
