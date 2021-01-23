    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            for (int i = 1; i <= 10; i++) // Outer loop for number of rows
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                for (int k = 10; k >= i; k--)
                {
                    Console.Write(" ");
                }            
                for (int l = 10-i; l >= 0; l--)
                {
                    Console.Write("*");
                }
                for (int k = 0; k <= i*2; k++) 
                {
                    Console.Write(" ");
                }
                for (int k = 10-i; k >= 0; k--)
                {
                    Console.Write("*");
                }
                for (int k = 10; k >= i; k--) 
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            } 
    
            Console.ReadKey();
            Console.Clear();
    
        }
    }
