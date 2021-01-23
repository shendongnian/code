    public interface IXYPair {
        double X { get; }
        double Y { get; }
    }
    class XYPair : IXYPair {
        public double X { get; set; }
        public double Y { get; set; }
        public override string ToString( ) {
            return string.Format( "X = {0} ; Y = {1}", X, Y );
        }
    }
    class Program {
        static List<double> XValues;
        static List<double> YValues;
        static void Main( string[ ] args ) {
            XValues = new List<double>( ) { 0.05, 0.25, 0.85, 0.95, 0.35, 1.65, 115.25 };
            YValues = new List<double>( ) { 0.25, 0.85, 1.15, 12.95, 7.35, 1.75, 0.13 };
            foreach ( IXYPair pair in XYPairsInRange( 0.5, 1.5 ) )
                Console.WriteLine( pair.ToString() );
        }
        public static IEnumerable<IXYPair> XYPairsInRange( double startX, double endX ) {
            foreach ( IXYPair pair in XYPairs ) {
                if ( pair.X >= startX && pair.X <= endX ) {
                    yield return pair;
                }
            }
        }
        public static IEnumerable<IXYPair> XYPairs {
            get {
                int counter = 0;
                foreach ( double x in XValues ) {
                    yield return new XYPair( ) { X = x, Y = YValues[ counter++ ] };
                }
            }
        }
    }
