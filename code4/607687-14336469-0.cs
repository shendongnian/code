    public class CoordinatesBasedComparer : IComparer, IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            if ((a.x == b.x) && (a.y == b.y))
                return 0;
            if ((a.x < b.x) || ((a.x == b.x) && (a.y < b.y)))
                return -1;
    
            return 1;
        }
        int IComparer.Compare(Object q, Object r)
        {
            return Compare((Point)q, (Point)r);            
        }
    }
