    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    namespace IsNumberTringularSeriesConsoleApp
    { 
        class Program
        {
            /// <summary>
            /// Listing all numbers comes under Triangular series.
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            static List<int> GetTriangularNumbers(int number)
            {
                List<int> lstTriangularNumbers = new List<int>();
                int i;
                int sum = 0;
                int triangularNumber = 0;
                for (i = 1; i < number; i++)
                {
                    sum = sum + i;
                    triangularNumber = sum;
                    lstTriangularNumbers.Add(triangularNumber);
                }
                return lstTriangularNumbers;
            }
 
            /// <summary>
            /// returns(count) the number of factors for each number
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static int FactorCount(int number)
            {
                List<int> factors = new List<int>();
                int max = (int)Math.Sqrt(number);  //round down
                for (int factor = 1; factor <= max; ++factor)
                { 
                    //test from 1 to the square root, or the int below it, inclusive.
                    if (number % factor == 0)
                    {
                        factors.Add(factor);
                        if (factor != number / factor)
                       {
                         // Don't add the square root twice!  
                            factors.Add(number / factor);
                       }
                    }
                }
                return factors.Count;
            }
            static void Main(string[] args)
            {
                List<int> lstTriangularNumbers = new List<int>();
                List<int> factors = new List<int>();
                int count = 0;
                //Getting the list of numbers comes under triangular series till 5000
                lstTriangularNumbers = GetTriangularNumbers(5000);
           
                foreach (int number in lstTriangularNumbers)
                {
                    /*
                     * Calling the FactorCount(number) function to check no of factors 
                     * available for the specific triangular number - number.
                     */
                     count = FactorCount(number);
                     //Console.WriteLine("No of factors for : " + number + " is : " + count);
                    if (count == 50)
                    {
                        Console.WriteLine("No of factors for first Triangular Number : " + number + " is : " + count);
                        break;
                    }
                }
                Console.ReadLine();
            }
        }
    }
