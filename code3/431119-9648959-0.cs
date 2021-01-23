    using System;
    
    class Test
    {
        static void Main()
        {
            Point point = new Point(10, 20);
            point.ReplaceWith(new Point(2, 3));
            Console.WriteLine(point); // (2, 3)
        }
    }
    
    struct Point
    {
        private readonly int x;
        private readonly int y;
        
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public void ReplaceWith(Point other)
        {
            this = other;
        }
        
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
