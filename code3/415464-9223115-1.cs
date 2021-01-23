    namespace PointCondenser
    {
        public static class Extensions
        {
            static public bool AlmostEqual<T>(this T value, T value2, T epsilon)
            {
                return (Math.Abs((dynamic)value - value2) < epsilon);
            }
        }
    
        public struct Point
        {
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
    
            public override string ToString()
            {
                return string.Format("{0}\t{1}", X, Y);
            }
    
            public double X;
            public double Y;
        }
        class Program
        {
            static public Point RandomYPoint(int i)
            {
                var r = new Random();
    
                var r2 = new Random(i);
    
                var variance = r2.NextDouble() / 100;
    
                return new Point(i, Math.Abs(r.NextDouble() - variance) * 100);
            }
    
            static public IEnumerable<Point> SmoothPoints(IEnumerable<Point> points, double percent)
            {
                if (percent <= 0 || percent >= 100)
                    throw new ArgumentOutOfRangeException("percent", "Percentage outside of logical bounds");
    
                var final = new List<Point>();
    
                var apoints = points.ToArray();
    
                var largestDifference = apoints.Max(x => x.Y) - apoints.Min(x => x.Y);
                var epsilon = largestDifference * percent;
    
                var currentPlateau = new List<Point> { apoints[0] };
    
                for (var i = 1; i < apoints.Count(); ++i)
                {
                    var point = apoints[i];
                    if (point.Y.AlmostEqual(currentPlateau.Average(x => x.Y), epsilon))
                        currentPlateau.Add(point);
                    else
                    {
                        var x = (currentPlateau[0].X + currentPlateau[currentPlateau.Count - 1].X) / 2.0;
                        var y = currentPlateau.Average(z => z.Y);
    
                        currentPlateau.Clear();
                        currentPlateau.Add(point);
    
                        final.Add(new Point(x, y));
                    }
                }
    
                return final;
            }
    
            static void Main(string[] args)
            {
                var r = new Random();
                var points = new List<Point>();
    
    
                for (var i = 0; i < 100; ++i)
                {
                    for (var n = 0; n < r.Next(1, 5); ++n)
                    {
                        var p = RandomYPoint(points.Count);
                        points.Add(p);
                        Console.WriteLine(p);
                    }
                    Thread.Sleep(r.Next(10, 250));
                }
    
                Console.Write("\n\n Condensed \n\n");
    
    
                var newPoints = SmoothPoints(points, .01);
    
                foreach (var p in newPoints)
                    Console.WriteLine(p);
            }
        }
    }
