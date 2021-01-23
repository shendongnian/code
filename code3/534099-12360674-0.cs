    public bool Sort(Shape shape)
    {
      foreach(Hole hole in Holes)
      {
         if(Hole.Type == HoleType.Circular && shape is Circle)
         {
             return true;
         }
         if(Hole.Type == HoleType.Square && shape is Square)
         {
             return true;
         }
         if(Hole.Type == HoleType.Triangular && shape is Triangle)
         {
             return true;
         }
      }
      return false;
    
    }
    
