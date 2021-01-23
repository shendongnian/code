    class Point: object 
    {
       protected int x, y;
    
       public Point(int xValue, int yValue)
       {
            x = xValue;
            y = yValue;
       }
       public override bool Equals(Object obj) 
       {
          // Check for null values and compare run-time types.
          if (obj == null || GetType() != obj.GetType()) 
             return false;
    
          Point p = (Point)obj;
          return (x == p.x) && (y == p.y);
       }
       public override int GetHashCode() 
       {
          return x ^ y;
       }
    }
