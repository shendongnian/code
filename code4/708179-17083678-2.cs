    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace _17082903_smallest_greatest_number
    {
        class Program
        {
            static void Main(string[] args)
            {
                int N = 2344;
                int n1 = 0;
                int n2 = 0;
    
                int d1 = SumDigits(N, ref n1);
                int d2 = ProductDigits(N, ref n2);
    
                bool sumFound = false, productFound = false;
    
                for (int i = N + 1; i < 1000000000; i++)
                {
                    if (!sumFound)
                    {
                        int stepsForSum = 0;
                        var res = SumDigits(i, ref stepsForSum);
    
                        if (res == d1 && n1 <= stepsForSum)
                        {
                            Console.WriteLine("the smallest number for sum is: " + i);
                            Console.WriteLine(string.Format("sum result is {0} in {1} steps only", res, stepsForSum));
                            sumFound = true;
                        }
                        n1 = 0;
                    }
    
                    if (!productFound)
                    {
                        int stepsForProduct = 0;
                        var res2 = ProductDigits(i, ref stepsForProduct);
    
                        if (res2 == d2 && n2 <= stepsForProduct)
                        {
                            Console.WriteLine("the smallest number for product is: " + i);
                            Console.WriteLine(string.Format("product result is {0} in {1} steps only", res2, stepsForProduct));
                            productFound = true;
                        }
                        n2 = 0;
                    }
    
                    if (productFound && sumFound)
                    {
                        break;
                    }
                }
    
            }
    
            static int SumDigits(int value, ref int numOfSteps)
            {
                int total = 0;
                while (value > 0)
                {
                    total += value % 10;
                    value /= 10;
                }
    
                numOfSteps++;
    
                if (total < 10)
                {
                    return total;
                }
                else
                {
                    return SumDigits(total, ref numOfSteps);
                }
            }
    
            static int ProductDigits(int value, ref int numOfSteps)
            {
                int total = 1;
                while (value > 0)
                {
                    total *= value % 10;
                    value /= 10;
                }
                numOfSteps++;
                if (total < 10)
                {
                    return total;
                }
                else
                {
                    return ProductDigits(total, ref numOfSteps);
                }
            }
        }
    }
