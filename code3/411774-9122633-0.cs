    public class MyData
    {
        public double[] rad
        {
            get;
            private set;
        }
        public MyData(int start, int stop, double tar)
        {
            rad = new double[Math.Abs(start - stop)];
            // More code here
        }
        // No need for an integrate method now - the work is done in the constructor
    }
