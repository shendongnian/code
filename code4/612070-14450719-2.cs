    public static class MathHelper
    {
        public const double TwoPi = Math.PI * 2.0;
        public static double DegToRad(double deg)
        {
            return (TwoPi / 360.0) * deg;
        }
        public static double RadToDeg(double rad)
        {
            return (360.0 / TwoPi) * rad;
        }
        
        // given an upper/lower bounds, "clamp" the value into that
        // range, wrapping over to lower if higher than upper, and
        // vice versa    
        public static int WrapClamp(int value, int lower, int upper)
        {
            return value > upper ? value - upper - 1
                : value < lower ? upper - value - 1
                : value;
        }
    }
