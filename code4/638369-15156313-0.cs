    class World
    {
        public static List<Animal> Animals = new List<Animal>();
        //...
    }
    class Deer : Animal
    {
        //...
        bool IsSafe()
        {
            return LookForWolves().All(wolf => !wolf.Hunting);
        }
        
        List<Wolf> LookForWolves()
        {
            return World.Animals.OfType<Wolf>();
        }
        //...
