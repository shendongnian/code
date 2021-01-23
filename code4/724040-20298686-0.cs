    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace TriangularSeries
    {
        class MyClass
        {
            static void Main(string[] args)
            {
                int result;
                TriangularSeries aSeries = new TriangularSeries();
                result = aSeries.TSeries();
                Console.WriteLine("The first Triangular Series number that has 50Factors is : " + result);
                Console.Read();
            }
        }
        //Find the Triangular Series numbers
        class TriangularSeries
        {
            public int TSeries()
            {
                int fCount = 0, T1 = 1, i = 1, T2 = 0, fval = 0;
                while (fCount != 50)
                {
                    i += 1;
                    T2 = T1 + i;
                    fCount = CalcFactors(T1);
                    fval = T1;                   
                    T1 = T2;
                
                }
                return fval;
            }
            public int CalcFactors(int num1)
            {
                List<int> factors = new List<int>();
                int max = (int)Math.Sqrt(num1);  //round down
                for (int factor = 1; factor <= max; ++factor)
                {
                    //test from 1 to the square root, or the int below it, inclusive.
                    if (num1 % factor == 0)
                    {
                        factors.Add(factor);
                        if (factor != num1 / factor)
                        {
                            // Don't add the square root twice!  
                            factors.Add(num1 / factor);
                        }
                    }
                }
                return factors.Count;
            }
        }   
    }
