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
            var maxY = a.Where(p => p.Y == a.Max(p1 => p1.Y)).ToArray();
            var minY = a.Where(p => p.Y == a.Min(p1 => p1.Y)).ToArray();
        }
    }
