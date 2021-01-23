    public struct Point2D: IEquatable<Point2D>
    {
        public Point2D(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }
        public bool Equals(Point2D other)
        {
            return _x == other._x && _y == other._x;
        }
        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Point2D))
            {
               return false;
            }
            return Equals((Point2D)obj);
        }
        public static bool operator==(Point2D point1, Point2D point2)
        {
            return point1.Equals(point2);
        }
        public static bool operator !=(Point2D point1, Point2D point2)
        {
            return !point1.Equals(point2);
        }
        public override string ToString()
        {
            return string.Format("({0}, {1})", _x, _y);
        }
        private readonly int _x;
        private readonly int _y;
    }
