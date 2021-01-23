    public class Planet
    {
      public Planet Parent; //if null, I'm the first in chain
      public float OrbitRadius; //From my parent
      public float OrbitAngle;  //0-360 around my parent
      public float Radius; //Planet size
    }
