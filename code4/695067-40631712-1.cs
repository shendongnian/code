    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int  n = 3 , x , sum = 0 ;
                double ave;
               
                for (int i = 0; i < n; i++ )
                {
                    Console.WriteLine("enter the number:");
                    x = Convert.ToInt16(Console.ReadLine());
                    sum += x;
                }
                    
                ave = (double)(sum) / 3;
                Console.WriteLine("average:");
                Console.WriteLine( ave );
                Console.ReadLine();
            }
        }
    }
