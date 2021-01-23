        class Program
        {
            public struct Point
            {
                int x, y;
                public Point(int x, int y) { this.x = x; this.y = y; }
            }
            
            static void Main(string[] args)
            {
                Point p1 = new Point();
                Point p2 = new Point(1, 1);
            }
        }
