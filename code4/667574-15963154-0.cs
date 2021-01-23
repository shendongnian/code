    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Do_while_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i = 20;
                Console.WriteLine();
                Console.WriteLine("A do while loop printing odd values from 20 - 0 ");
             do 
             {
                if (i-- %2 !=0)
                {
                 Console.WriteLine("When counting down from 20 the odd values are: {0}", i--);
                }
    
             } while (i >=0);
             Console.ReadLine();  
            }
    
        }
    }
