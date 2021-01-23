    class Point : IEquatable<Point>
    {
       public Equals(Point other)
       {
           return other != null && this.x == other.x && this.y == other.y;
       }
       
       public override bool Equals(Object obj) 
       {
           return this.Equals(obj as Point);
       }
    }
