    public struct Fixed8
    {
        public Fixed8(double value)
        {
            _numerator = (long)(value * DENOMINATOR);
        }
        private long _numerator;
        public const long DENOMINATOR = 1 << 24;
        public static Fixed8 operator /(Fixed8 a, Fixed8 b)
        {
            long remainder;
            long quotient = Math.DivRem(a._numerator, b._numerator, out remainder) * DENOMINATOR;
            long morePrecision = remainder * DENOMINATOR / b._numerator;
            return new Fixed8 { _numerator = quotient + morePrecision };
        }
    }
