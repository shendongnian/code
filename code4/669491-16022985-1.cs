    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace CartesianProduct
    {
        class Program
        {
            static void Main(string[] args)
            {
                char[] array1 = new char[] { 'A', 'B' };
                char[] array2 = new char[] { 'C', 'D', 'E' };
                char[] array3 = new char[] { 'F', 'G', 'H' };
    
                int iterations = array1.Length * array2.Length * array3.Length;
    
                for (int i = 0; i < iterations; i++)
                {
                    Console.WriteLine("{0}, {1}, {2}", array1[i % array1.Length], array2[i % array2.Length], array3[i % array3.Length]);
                }
                Console.WriteLine("Total iterations: " + iterations.ToString());
                Console.Read();
            }
        }
    }
