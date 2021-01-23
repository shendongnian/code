    using System;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                double z = zero();
                double r = z.Times(number);
                Console.WriteLine(r);
            }
            static double zero()
            {
                return 0;
            }
            static double number()
            {
                Console.WriteLine("in number()");
                return 100;
            }
        }
        public static class DoubleExt
        {
            public static double Times(this double val, Func<double> anotherValue)
            {
                const double epsilon = 0.00000001;
                return Math.Abs(val) < epsilon ? 0 : val * anotherValue();
            }
        }
    }
