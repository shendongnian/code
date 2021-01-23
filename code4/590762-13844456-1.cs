    class TwoDPoint : System.Object
    {
        public readonly int x, y;
    
        public TwoDPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    
        public override bool Equals(System.Object obj)
        {
            if (obj == null) return false;
    
            TwoDPoint p = obj as TwoDPoint;
            if (p == null) return false;
               
            // Return true if the fields match
            return (x == p.x) && (y == p.y);
        }
    
        public override int GetHashCode()
        {
            return x ^ y;
        }
    }
