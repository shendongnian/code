    public static Func<string> ReflectByName( object obj, string methodname ) {
        return ( ) => {
            return ( string )( obj.GetType( ).GetMethod( methodname ).Invoke( obj, new object[ 0 ] ) );
        }
    }
