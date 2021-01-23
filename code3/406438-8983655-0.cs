    using System;
    class Program {
        static Func<T2, TRes> Curry<T1, T2, TRes>(Func<T1, T2, TRes> f, T1 t1) {
            return (t2) => f(t1, t2);
        }
        static double PowerFunction(double d1, double d2) {
            return Math.Pow(d1, d2);
        }
        static void Main(string[] args) {
            var powerOf2 = Curry<double, double, double>(PowerFunction, 2);
            double r = powerOf2(3);
        }
    }
