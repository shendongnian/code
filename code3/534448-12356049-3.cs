    class Program {
        static void Main( string[ ] args ) {
            CustomizedConsole.WriteLine( "Lorem Ipsum" ); //Lorem Ipsum
            Console.WriteLine( CustomizedConsole.ReadContent( 6, 5 ) ); //Ipsum
            Console.WriteLine( CustomizedConsole.GetCharAtLocation( 0, 0 ) ); //L
        }
    }
    static class CustomizedConsole {
        private static List<char> buffer = new List<char>();
        private static int lineCharCount = 0;
        public static void Write(string s){
            lineCharCount += s.Length;
            buffer.AddRange( s );
            Console.Write( s );
            if(buffer.Length > Console.BufferWidth * Console.BufferHeight){
               buffer = new List<char>();
               lineCharCount = 0;
            }
        }
        public static void WriteLine(string s ) {
            for ( int i = 0; i < Console.BufferWidth - lineCharCount - s.Length; i++ )
                s += " ";
            buffer.AddRange( s );
            Console.WriteLine( s );
            lineCharCount = 0;
            
            if(buffer.Length > Console.BufferWidth * Console.BufferHeight)
               buffer = new List<char>();
        }
        public static string ReadContent( int index, int count ) {
            return new String(buffer.Skip( index ).Take( count ).ToArray());
        }
 
        public static char GetCharAtLocation( int x, int y ) {
            return buffer[ x * y ];
        }
    }
