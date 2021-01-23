    class Program
    {
        static void Main(string[] args)
        {
            DashedLine line = new DashedLine();
            line.Points.Add(new Point { X = 1, Y = 1 });
            line.Points.Add(new Point { X = 2, Y = 2 });
            line.Points.Add(new Point { X = 3, Y = 3 });
            line.Points.Add(new Point { X = 4, Y = 4 });
            foreach (Point p in line.Points)
            {
                Debug.WriteLine("Point {0}, {1}", p.X, p.Y);
            }
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class DashedLine
    {
        public List<Point> Points { get; set; }
        public DashedLine()
        {
            Points = new List<Point>();
        }
    }
