    class Program
    {
        static void Main(string[] args)
        {
            Point[] a = new Point[]{
                new Point() { X = 0, Y = 3 },
                new Point() { X = 1, Y = 3 },
                new Point() { X = 2, Y = 1 },
                new Point() { X = 3, Y = 1 },
                new Point() { X = 1, Y = 2 }
            };
            var max = a.Max(p1 => p1.Y);
            var min = a.Min(p1 => p1.Y);
            var maxY = a.Where(p => p.Y == max).ToArray();
            var minY = a.Where(p => p.Y == min).ToArray();
        }
    }
