    public class AlmostDoubleComparer : IComparer<double>
    {
        public static readonly AlmostDoubleComparer Default = new AlmostDoubleComparer();
        public const double Epsilon = double.Epsilon * 64d; // 0.{322 zeroes}316
        public static bool IsZero(double x)
        {
            return Compare(x, 0) == 0;
        }
        public static int Compare(double x, double y)
        {
            // Very important that cmp(x, y) == cmp(y, x)
            if (Double.IsNaN(x) || Double.IsNaN(y))
                return 1;
            if (Double.IsInfinity(x) || Double.IsInfinity(y))
                return 1;
            var absX = Math.Abs(x);
            var absY = Math.Abs(y);
            var diff = absX > absY ? absX - absY : absY - absX;
            if (diff < Epsilon)
                return 0;
            if (x < y)
                return -1;
            else
                return 1;
        }
        int IComparer<double>.Compare(double x, double y)
        {
            return Compare(x, y);
        }
    }
    
    // E.g.
    double arg = (Math.PI / 2d - Math.Atan2(a, d));
    if (AlmostDoubleComparer.IsZero(arg))
       // Regard it as zero.
