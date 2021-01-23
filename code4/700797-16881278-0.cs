    class MyRandom
    {
        private static Random Rand = new Random();
        private static Dictionary<int, int> LookupTable = new Dictionary<int, int>();
        public static int RandomInt( int seed )
        {
            try
            {
                return LookupTable[ seed ];
            }
            catch ( Exception e )
            {
                int retNum = Rand.Next();
                LookupTable.Add( seed, retNum );
                return retNum;
            }
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( MyRandom.RandomInt( 3 ) );
            Console.WriteLine( MyRandom.RandomInt( 1 ) );
            Console.WriteLine( MyRandom.RandomInt( 3 ) );
        }
    }
