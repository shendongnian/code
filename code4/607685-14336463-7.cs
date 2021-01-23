    public class CoordinatesBasedComparer : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            if ((a.x == b.x) && (a.y == b.y))
                return 0;
            if ((a.x < b.x) || ((a.x == b.x) && (a.y < b.y)))
                return -1;
    
            return 1;
        }
    }
    
