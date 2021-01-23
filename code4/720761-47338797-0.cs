    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestCorrel {
        class Program {
    
            static void Main(string[] args) {
    
                Random rand = new Random(DateTime.Now.Millisecond);
    
                List<double> x = new List<double>();
                List<double> y = new List<double>();
    
                for (int i = 0; i < 100; i++) {
    
                    x.Add(rand.Next(1000) * rand.NextDouble());
                    y.Add(rand.Next(1000) * rand.NextDouble());
    
                    Console.WriteLine(x[i] + "," + y[i]);
                }
    
                Console.WriteLine("Correl1: " + Correl1(x, y));
                Console.WriteLine("Correl2: " + Correl2(x, y));
            }
    
            public static double Correl1(List<double> x, List<double> y) {
    
                //https://stackoverflow.com/questions/17447817/correlation-of-two-arrays-in-c-sharp
                if (x.Count != y.Count)
                    return (double.NaN); //throw new ArgumentException("values must be the same length");
    
                double sumX = 0;
                double sumX2 = 0;
                double sumY = 0;
                double sumY2 = 0;
                double sumXY = 0;
    
                int n = x.Count < y.Count ? x.Count : y.Count;
    
                for (int i = 0; i < n; ++i) {
    
                    Double xval = x[i];
                    Double yval = y[i];
    
                    sumX += xval;
                    sumX2 += xval * xval;
                    sumY += yval;
                    sumY2 += yval * yval;
                    sumXY += xval * yval;
                }
    
                Double stdX = Math.Sqrt(sumX2 / n - sumX * sumX / n / n);
                Double stdY = Math.Sqrt(sumY2 / n - sumY * sumY / n / n);
                Double covariance = (sumXY / n - sumX * sumY / n / n);
    
                return covariance / stdX / stdY;
            }
    
            public static double Correl2(List<double> x, List<double> y) {
    
                double[] array_xy = new double[x.Count];
                double[] array_xp2 = new double[x.Count];
                double[] array_yp2 = new double[x.Count];
    
                for (int i = 0; i < x.Count; i++)
                    array_xy[i] = x[i] * y[i];
                for (int i = 0; i < x.Count; i++)
                    array_xp2[i] = Math.Pow(x[i], 2.0);
                for (int i = 0; i < x.Count; i++)
                    array_yp2[i] = Math.Pow(y[i], 2.0);
                double sum_x = 0;
                double sum_y = 0;
                foreach (double n in x)
                    sum_x += n;
                foreach (double n in y)
                    sum_y += n;
                double sum_xy = 0;
                foreach (double n in array_xy)
                    sum_xy += n;
                double sum_xpow2 = 0;
                foreach (double n in array_xp2)
                    sum_xpow2 += n;
                double sum_ypow2 = 0;
                foreach (double n in array_yp2)
                    sum_ypow2 += n;
                double Ex2 = Math.Pow(sum_x, 2.00);
                double Ey2 = Math.Pow(sum_y, 2.00);
                 
                double Correl = 
                (x.Count * sum_xy - sum_x * sum_y) /
                Math.Sqrt((x.Count * sum_xpow2 - Ex2) * (x.Count * sum_ypow2 - Ey2));
    
                return (Correl);
            }
        }
    }
