    static class Program
    {
        public static void AddIfNotNull(this Dictionary<string,object> target, string key, object value )
        {
            if( value != null )
                target.Add( key, value );
        }
    
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, object>( );
    
            dictionary.AddIfNotNull( "not-added",    null );
            dictionary.AddIfNotNull( "added",       "true" );
    
            foreach( var item in dictionary )
                Console.WriteLine( item.Key );
    
            Console.Read( );
        }
    
    }
