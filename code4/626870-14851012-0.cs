    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
     
    namespace ConsoleApplication59
    {
        class Program
        {
            static void Main(string[] args)
            {
                int numberoflayer = 6, Space, Number;
                Console.WriteLine("Print paramid");
                for (int i = 1; i <= numberoflayer; i++) // Total number of layer for pramid
                {
                    for (Space = 1; Space <= (numberoflayer - i); Space++)  // Loop For Space
                        Console.Write(" ");
                    for (Number = 1; Number <= i; Number++) //increase the value
                        Console.Write(Number);
                    for (Number = (i - 1); Number >= 1; Number--)  //decrease the value
                        Console.Write(Number);
                    Console.WriteLine();
                    }
                }
        }
    }
