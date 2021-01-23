    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point(1, 2);
            Point b = new Point(2, 4);
            Point c=a.AddPoints(b);
        }
    }
    public static class MyExtensions
    {
        public static Point AddPoints(this Point x, Point y)
        {
            return new Point(x.X + y.X, x.Y + y.Y);
        }
    }  
