    public interface Polygon
    {
      float GetArea();
    }
    public class Square : Polygon
    {
      float Side;
      public Square(float side)
      {
        Side = side;
      }
      Polygon.GetArea()
      {
        return side*side;
      } 
    }
