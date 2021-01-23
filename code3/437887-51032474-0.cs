    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static int Main(string[] args)
            {
    
                int n, i = 0, c;
                Console.WriteLine("Enter the number of terms:");
                n = Convert.ToInt16(Console.ReadLine());
    
                Console.WriteLine("Fibonacci series\n");
               
                for (c = 1; c <= n; c++)
                {
                    int result = FibonacciFunction(i);
                    Console.Write(result + " " );
                    i++;
                }
                Console.WriteLine();
                return 0;
            }
    
            public static int FibonacciFunction(int n)
            {
                if (n == 0)
                {
                    return 0;
                }
                else if (n == 1)
                {
                    return 1;
                }
                else
                {
                    return (FibonacciFunction(n - 1) + FibonacciFunction(n - 2));
                }
            }
    
        }
    }
