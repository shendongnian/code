    namespace _17082903_smallest_greatest_number
    {
        class Program
        {
            static void Main(string[] args)
            {
                int N = 2345;
                int n1 = 0;
                int n2 = 0;
    
                int smallestStepsSum = 5, smallestNSum = 7;
                int smallestStepsProduct = 5, smallestNProduct = 0;
    
                for (int i = N + 1; i < 1000000000; i++)
                {
                    var res = SumDigits(i, ref n1);
    
                    if (res == smallestNSum && n1 <= smallestStepsSum)
                    {
                        Console.WriteLine("the smallest number for sum is: " + i);
                        break;
                    }
                }
    
                for (int i = N + 1; i < 1000000000; i++)
                {
                    var res2 = ProductDigits(i, ref n2);
    
                    if (res2 == smallestNProduct && n1 <= smallestStepsProduct)
                    {
                        Console.WriteLine("the smallest number for product is: " + i);
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
