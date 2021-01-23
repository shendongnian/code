    public bool Intersects(Rect r1,Rect r2)
    {
      r1.Intersect(r2);
      
      if(r1.IsEmpty)
      {
        return false;
      }
      else 
      {
        return true;
      }
    }
