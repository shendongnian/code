    public enum Planet
    {
        Mercury = 1 ,
        Venus   = 2 ,
        Earth   = 3 ,
        Mars    = 4 ,
        Jupiter = 5 ,
        Saturn  = 6 ,
        Uranus  = 7 ,
        Neptune = 8 ,
    }
    public interface IPlanetData
    {
        double Mass   { get ; }
        double Radius { get ; }
    }
    public static class PlanetEnumHelpers
    {
        private class PlanetData : IPlanetData
        {
            internal PlanetData( double mass , double radius )
            {
                Mass = mass ;
                Radius = radius ;
            }
            public double Mass   { get ; private set ; }
            public double Radius { get ; private set ; }
        }
        public static IPlanetData Data( this Planet planet )
        {
            IPlanetData instance ;
            switch ( planet )
            {
                case Planet.Mercury : instance = Mercury ; break ;
                case Planet.Venus   : instance = Venus   ; break ;
                case Planet.Earth   : instance = Earth   ; break ;
                case Planet.Mars    : instance = Mars    ; break ;
                case Planet.Jupiter : instance = Jupiter ; break ;
                case Planet.Saturn  : instance = Saturn  ; break ;
                case Planet.Uranus  : instance = Uranus  ; break ;
                case Planet.Neptune : instance = Neptune ; break ;
                default : throw new ArgumentOutOfRangeException("planet") ;
            }
            return instance ;
        }
        private static IPlanetData Mercury = new PlanetData( 3.303e+23 , 2.4397e6  ) ;
        private static IPlanetData Venus   = new PlanetData( 4.869e+24 , 6.0518e6  ) ;
        private static IPlanetData Earth   = new PlanetData( 5.976e+24 , 6.37814e6 ) ;
        private static IPlanetData Mars    = new PlanetData( 6.421e+23 , 3.3972e6  ) ;
        private static IPlanetData Jupiter = new PlanetData( 1.9e+27   , 7.1492e7  ) ;
        private static IPlanetData Saturn  = new PlanetData( 5.688e+26 , 6.0268e7  ) ;
        private static IPlanetData Uranus  = new PlanetData( 8.686e+25 , 2.5559e7  ) ;
        private static IPlanetData Neptune = new PlanetData( 1.024e+26 , 2.4746e7  ) ;
    }
    class Program
    {
        static void Main( string[] args )
        {
            foreach ( Planet p in Enum.GetValues( typeof( Planet ) ) )
            {
                Console.WriteLine( "{0}: Mass={1} Radius={2}" , p , p.Data().Mass , p.Data().Radius );
            }
        }
    }
