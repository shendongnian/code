    public static class Planets
    {
        // static cctor
        static Planets()
        {
            Saturn = new SaturnPlanet();
            Earth = new EarthPlanet();
            ...
        }
        public static Planet Saturn { get; private set; }
        public static Planet Earth { get; private set; }
        ...
    }
