    public struct PolarVector {
        public double Radius { get; set; }
        public double Angle { get; set; }
    
        public override string ToString() {
            return "{" + Radius + "," + Angle + "}";
        }
    }
    
    private static void Main(string[] args) {
        var points = new[] {
                                new Point {X = 0, Y = 0},
                                //new Point {X = 2, Y = 0},
                                new Point {X = 0, Y = 2},
                                new Point {X = 1.5, Y = 0.5},
                                new Point {X = 2, Y = 2},
                            };
        foreach(var point in ConvexHull(points)) {
            Console.WriteLine(point);
        }
        Console.WriteLine();
        if(Debugger.IsAttached) {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    
    public static IList<Point> ConvexHull(IList<Point> points) {
        var pointOnHull = LeftMost(points);
        var pointsOnHull = new List<Point>();
        Point currentPoint;
        do {
            pointsOnHull.Add(pointOnHull);
            currentPoint = points[0];
            foreach(var nextPoint in points.Skip(1)) {
                if (currentPoint == pointOnHull || IsLeft(nextPoint, pointOnHull, currentPoint)) {
                    currentPoint = nextPoint;
                }
            }
            pointOnHull = currentPoint;
        }
        while (currentPoint != pointsOnHull[0]);
        return pointsOnHull;
    }
    
    private static Point LeftMost(IEnumerable<Point> points) {
        return points.Aggregate((v1, v2) => v2.X < v1.X ? v2 : v1);
    }
    
    private static bool IsLeft(Point nextPoint, Point lastPoint, Point currentPoint) {
        var nextVector = ToPolar(nextPoint, lastPoint);
        var currentVector = ToPolar(currentPoint, lastPoint);
        return nextVector.Radius != 0 && Normalize(nextVector.Angle - currentVector.Angle) > 0;
    }
    
    private static PolarVector ToPolar(Point target, Point start) {
        var vector = target - start;
        return new PolarVector { Radius = Math.Sqrt((vector.Y * vector.Y) + (vector.X * vector.X)), Angle = Math.Atan2(vector.Y, vector.X)};
    }
    
    private static double Normalize(double radians) {
        while(radians > Math.PI) {
            radians -= 2*Math.PI;
        }
        while (radians < -Math.PI) {
            radians += 2*Math.PI;
        }
        return radians;
    }
