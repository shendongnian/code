        /// <summary>
        /// Return the integral from a to b of function f
        /// using the left hand rule
        /// </summary>
        public static double IntegrateLeftHand(double a, 
                                               double b, 
                                               Func<double,double> f, 
                                               int strips = -1) {
            if (a >= b) return -1;              // a must be greater than b
            // if strips is not provided, calculate it
            if (strips == -1) {
                strips = 100;
                for (int i = (int)a; i < b; i++)
                    strips = (strips > f(i)) ? strips : (int)f(i);
            }
            double h = (double)(b - a) * 1.0 / strips;
            double acc = 0.0;
            for (int i = 0; i < strips; i++)    acc += h * f(a + i * h);
            return acc;
        }
        /// <summary>
        /// Return the integral from a to b of function f 
        /// using the midpoint rule
        /// </summary>
        public static double IntegrateMidPoint(double a, 
                                               double b, 
                                               Func<double, double> f, 
                                               int strips = -1) {
            if (a >= b) return -1;              // constraint: a must be greater than b
            // if strips is not provided, calculate it
            if (strips == -1) {
                strips = 100;
                for (int i = (int)a; i < b; i++)
                    strips = (strips > f(i)) ? strips : (int)f(i);
            }
            double h = (double)(b - a) * 1.0 / strips;
            double x = a + h / 2;
            double acc = 0.0;
            while (x < b) {
                acc += h * f(x);
                x += h;
            }
            return acc;
        }
        /// <summary>
        /// Return the integral from a to b of function f
        /// using trapezoidal rule
        /// </summary>
        public static double IntegrateTrapezoidal(double a, 
                                                  double b, 
                                                  Func<double, double> f, 
                                                  int strips = -1) {
            if (a >= b) return -1;              // constraint: a must be greater than b
            // if strips is not provided, calculate it
            if (strips == -1)
            {
                strips = 100;
                for (int i = (int)a; i < b; i++)
                    strips = (strips > f(i)) ? strips : (int)f(i);
            }
            double h = (double)(b - a) * 1.0 / strips;
            double acc = (h / 2) * (f(a) + f(b));
            for (int i = 1; i < strips; i++)    acc += h * f(a + i * h);
            return acc;
        }
    Console.WriteLine("with strips: {0}", IntegrateLeftHand(0, Math.PI, Math.Sin, 1440));
    Console.WriteLine("without strips: {0}", IntegrateMidPoint(0, 30, x => x * x));
    // or with a defined method for f(x)
    public static double myFunc(x) { return x * (x + 1); }
    Console.WriteLine("with strips: {0}", IntegrateLeftHand(0, 20, myFunc, 200));
