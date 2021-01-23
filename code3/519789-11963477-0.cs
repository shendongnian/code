    class AridPlanet : Arid
    {
        public AridPlanet()
        {
            area = 95;
        }
    }
    
    abstract class Arid : Astro
    {
        public Arid()
        {
            metal = 2;
            gas = 2;
            crystals = 0;
            fertility = 5;
        }
    
    }
    
