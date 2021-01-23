    public static class MyExtension
    {
        public static decimal ToDecimal(this double d)
        {
            return Convert.ToDecimal(d);
        }
    
        public static double ToDouble(this decimal d)
        {
            return Convert.ToDouble(d);
        }
    }
