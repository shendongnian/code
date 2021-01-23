    public Hole Sort(IShape shape)
    {
       foreach(Hole hole in Holes)
       {
          if(hole.HoleType == shape.ShapeType && hole.Area >= shape.Area)
          {
             return hole;
          }
       }
       return null;
    }
