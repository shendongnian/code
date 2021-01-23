    class Program {
        static void Main( string[ ] args ) {
            Stopwatch sw = Stopwatch.StartNew( );
            for ( int i = 0; i < 1000000000; i++ ) //1 billion times
                IsFileURI1( "File:\\ThisIsATest" );
            sw.Stop( );
            Console.WriteLine( "String.StartsWith(): " + sw.ElapsedMilliseconds.ToString( ) );
            sw.Restart( );
            for ( int i = 0; i < 1000000000; i++ ) //1 billion times
                IsFileURI2( "File:\\ThisIsATest" );
            sw.Stop( );
            Console.WriteLine( "String.Equals(): " + sw.ElapsedMilliseconds.ToString( ) );
        }
        public static bool IsFileURI1( string path ) {
            return path.StartsWith( "FILE:", StringComparison.OrdinalIgnoreCase );
        }
        public static bool IsFileURI2( string path ) {
            if ( path.Length < 5 ) return false;
            return String.Equals( path.Substring( 0, 5 ), "FILE:", StringComparison.OrdinalIgnoreCase );
        }   
    }
