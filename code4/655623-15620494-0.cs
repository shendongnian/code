    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Euler
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int max = 10;
                int sum = 0;
    
                for (int i = 0; i < max; i++)
                {
                    if (i % 3 == 0 || i % 5 == 0)
                        sum += i;
                }
    
                Console.WriteLine("The sum of all multiples of 3 and 5 from 0 to {0} is: {1}", max, sum);
                
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
