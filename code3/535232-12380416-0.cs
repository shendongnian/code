    class Program
    {
        public struct Point
        {
            public int x, y;
            public Point(int x, int y) { this.x = x; this.y = y; }
        }
        static void Main(string[] args)
        {
            var p1 = new Point();
            var p2 = new Point(1, 1);
            p1.x = 1;
            p1.y = 1;
        }
    }
