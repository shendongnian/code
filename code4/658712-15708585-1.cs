    class Program {
        static void Main( string[ ] args ) {
            string[] binary = { "{0000}", "{0001}", "{0111}" };
            var differentNumbers = DifferentNumbers( binary );
            foreach ( Tuple<string, string, int> tuple in differentNumbers )
                Console.WriteLine( string.Format( "{0} ; {1} - index {2}", tuple.Item1, tuple.Item2, tuple.Item3 ) );
        }
        public static List<Tuple<string, string, int>> DifferentNumbers( string[ ] array ) {
            var differentNumbers = new List<Tuple<string, string, int>>( );
            for ( int i = 0; i < array.Length; i++ ) {
                for ( int j = i + 1; j < array.Length; j++ ) {
                    int count = 0, index = 0;
                    for ( int c = 1; c < array[ i ].Length - 1; c++ ) {
                        if ( array[ i ][ c ] != array[ j ][ c ] ) {
                            index = c;
                            if ( count++ > 1 )
                                break;
                        }
                    }
                    if ( count == 1 )
                        differentNumbers.Add( new Tuple<string, string, int>( array[ i ], array[ j ], index ) );
                }
            }
            return differentNumbers;
        }
    }
