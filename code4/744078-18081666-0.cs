    public struct Point : IEqutable<Point>
    {
        private readonly int x, y;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override int GetHashCode()
        {
            return 31 * x + 17 * y; // Or something like that
        }
        public bool Equals(object obj)
        {
            return obj is Point && Equals((Point) obj);
        }
        public bool Equals(Point p)
        {
            return x == p.x && y == p.y;
        }
    }
