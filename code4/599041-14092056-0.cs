    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
   
    namespace Misc
    {
        class Program
        {
            static int duplicates(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == array.Length) continue;
                    if (array[i] == array[i+1])
                    {
                        return i;
                    }
                }
                return -1;
            }
    
            static void Main(string[] args)
            {
                int[] testArray = { 1, 5, 6, 8, 9, 4, 4, 6, 3, 2 };
                Console.WriteLine(duplicates(testArray));
                Console.ReadKey(); // block 
            }
        }
    }
