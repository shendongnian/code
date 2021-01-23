    public class AlmostDoubleComparer : IComparer<double>
    {
        public static readonly AlmostDoubleComparer Default = new AlmostDoubleComparer();
        public const double MaxUnitsInTheLastPlace = 3;
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
            var ix = DoubleInt64.Reinterpret(x);
            var iy = DoubleInt64.Reinterpret(y);
            var diff = Math.Abs(ix - iy);
            if (diff < MaxUnitsInTheLastPlace)
                return 0;
            if (ix < iy)
                return -1;
            else
                return 1;
        }
        int IComparer<double>.Compare(double x, double y)
        {
            return Compare(x, y);
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct DoubleInt64
    {
        [FieldOffset(0)]
        private double _double;
        [FieldOffset(0)]
        private long _int64;
        private DoubleInt64(long value)
        {
            _double = 0d;
            _int64 = value;
        }
        private DoubleInt64(double value)
        {
            _int64 = 0;
            _double = value;
        }
        public static double Reinterpret(long value)
        {
            return new DoubleInt64(value)._double;
        }
        public static long Reinterpret(double value)
        {
            return new DoubleInt64(value)._int64;
        }
    }
