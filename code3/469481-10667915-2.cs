    struct PointStruct
    {
      int X;
      int Y;
      // its a low memory integer
      int Color;      
    }
    // multiple element container
    class CADAppClass
    {
      List<Point> Points;
      public void assignPoint
        (ref PointStruct Point, int NewX, int NewY, Color NewColor) { ... }
      public void movePoint
        (ref PointStruct Point, int addX, int addNewY) { ... }
     // ...
    }
