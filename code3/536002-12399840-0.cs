    public class Point : IComparable<Point>
    {
        private int x;
        private int y;
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        public Point(int xp, int yp)
        {
            x = xp;
            y = yp;
        }
        public int CompareTo(Point other)
        {
            // Custom comparison here
        }
    }
