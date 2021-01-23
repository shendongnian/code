    class PointClass
    {
      int X;
      int Y;
      // its also an object / class
      Color Color;
      
      public void assign(int NewX, int NewY, Color NewColor) { ... }
      public void move(int addX, int addNewY) { ... }
    }
    // multiple element container
    class CADAppClass
    {
      List<Point> Points;
     // ...
    }
    // Not enough memory Exception !!!
