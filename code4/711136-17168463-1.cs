    using System.Runtime.InteropServices;
    
    class DllWrapper
    {
        [DllImport("CalSimpleInterest.dll")]
        public static extern double CalSimplInterest(double Principal, double Rate, double Time);
    }
