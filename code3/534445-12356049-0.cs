    class Program {
        static void Main( string[ ] args ) {
            CustomizedConsole.WriteLine( "Lorem Ipsum" ); //Lorem Ipsum
            string s = CustomizedConsole.ReadContent( 6, 5 );
            Console.WriteLine( s ); //Ipsum
        }
    }
    static class CustomizedConsole {
        private static List<char> buffer = new List<char>();
        public static void WriteLine(string s){
            buffer.AddRange( s );
            Console.WriteLine( s );
        }
        public static string ReadContent( int index, int count ) {
            return new String(buffer.Skip( index ).Take( count ).ToArray());
        }
    }
