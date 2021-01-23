    public class Terrain {
       public int Chance {get;private set;}
       public int LengthMin {get;private set;}
       // ...
       private Terrain(int chance, int lengthMin, ...) {
           Chance = chance;
           LengthMin = lengthMin;
           // ...
       }
       private static readonly Terrain
           desert = new Terrain(45, 45, ...),
           meadow = new Terrain(15, 60, ...),
           ...;
       public static Terrain Desert { get { return desert;}}
       public static Terrain Meadow { get { return meadow;}}
    }
    
