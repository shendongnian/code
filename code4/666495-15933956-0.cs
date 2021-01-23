    public static class EnumHelper
    {
        public static T Min<T>(T a, T b)
        {
            return (dynamic)a < (dynamic)b ? a : b;
        }
        public static T Max<T>(T a, T b)
        {
            return (dynamic)a > (dynamic)b ? a : b;
        }
    }
