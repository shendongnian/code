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
    
                int smallestStepsSum = 5, smallestNSum = 7;
                int smallestStepsProduct = 5, smallestNProduct = 0;
    
                bool sumFound = false, productFound = false;
    
                for (int i = N + 1; i < 1000000000; i++)
                {
                    if (!sumFound)
                    {
                        var res = SumDigits(i, ref n1);
    
                        if (res == smallestNSum && n1 <= smallestStepsSum)
                        {
                            Console.WriteLine("the smallest number for sum is: " + i);
                            Console.WriteLine(string.Format("sum result is {0} in {1} steps only", res, n1));
                            sumFound = true;
                        }
                        n1 = 0;
                    }
    
                    if (!productFound)
                    {
                        var res2 = ProductDigits(i, ref n2);
    
                        if (res2 == smallestNProduct && n2 <= smallestStepsProduct)
                        {
                            Console.WriteLine("the smallest number for product is: " + i);
                            Console.WriteLine(string.Format("product result is {0} in {1} steps only", res2, n2));
                            productFound = true;
                        }
                        n2 = 0;
                    }
    
                    if (productFound && sumFound)
                    {
                        break;
                    }
                }
    
                for (int i = N + 1; i < 1000000000; i++)
                {
                    var res2 = ProductDigits(i, ref n2);
    
                    if (res2 == smallestNProduct && n2 <= smallestStepsProduct)
                    {
                        Console.WriteLine("the smallest number for product is: " + i);
                        Console.WriteLine(string.Format("product result is {0} in {1} steps only", res2, n2));
                        break;
                    }
                    n2 = 0;
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
