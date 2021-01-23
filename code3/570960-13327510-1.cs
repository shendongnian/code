    public class Planet
    {
      public Planet Parent; //if null, I'm the first in chain
      public float OrbitRadius; //From my parent
      public float OrbitAngle;  //0-360 around my parent
      public float Radius; //Planet size
      //EDIT:
      public Vector3 Position;
      public void CalculatePosition()
      {
        if(Parent == null) Position = new Position(0, 0, 0);
        Position = Parent.Position + OrbitRadius * Math.Sin(OrbitAngle * Math.PI / 180.0f);
      }
    }
