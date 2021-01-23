    class All
     {
        private static object lockAll = new object();
        public All ()
        {
           lock(lockAll)
           {
               double res= Magnitude(1d, 0.1d , 0.2d);
           }
        }
        private double Magnitude(double X, double Y, double Z)
        {
           return Math.Sqrt(X * X + Y * Y + Z * Z);
        }
     }
