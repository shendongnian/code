    public class XYPoint
    {
        public int X;
        public double Y;
    }
    class Program
    {
        public static List<XYPoint> GenerateLinearBestFit(List<XYPoint> points, out double a, out double b)
        {
            int numPoints = points.Count;
            double meanX = points.Average(point => point.X);
            double meanY = points.Average(point => point.Y);
            double sumXSquared = points.Sum(point => point.X * point.X);
            double sumXY = points.Sum(point => point.X * point.Y);
            a = (sumXY / numPoints - meanX * meanY) / (sumXSquared / numPoints - meanX * meanX);
            b = (a * meanX - meanY);
            double a1 = a;
            double b1 = b;
            return points.Select(point => new XYPoint() { X = point.X, Y = a1 * point.X - b1 }).ToList();
        }
        static void Main(string[] args)
        {
            List<XYPoint> points = new List<XYPoint>()
                                       {
                                           new XYPoint() {X = 1, Y = 12},
                                           new XYPoint() {X = 2, Y = 16},
                                           new XYPoint() {X = 3, Y = 34},
                                           new XYPoint() {X = 4, Y = 45},
                                           new XYPoint() {X = 5, Y = 47}
                                       };
            double a, b;
            List<XYPoint> bestFit = GenerateLinearBestFit(points, out a, out b);
            Console.WriteLine("y = {0:#.####}x {1:+#.####;-#.####}", a, -b);
            for(int index = 0; index < points.Count; index++)
            {
                Console.WriteLine("X = {0}, Y = {1}, Fit = {2:#.###}", points[index].X, points[index].Y, bestFit[index].Y);
            }
        }
    }
