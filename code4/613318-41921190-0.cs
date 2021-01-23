    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class RnDHash
        {
            static void Main()
            {
                HashSet<int> rndIndexes = new HashSet<int>();
                Random rng = new Random();
                int maxNumber;
                Console.Write("Please input Max number: ");
                maxNumber = int.Parse(Console.ReadLine());
                int iter = 0;
                while (rndIndexes.Count != maxNumber)
                {
                    int index = rng.Next(maxNumber);
                    rndIndexes.Add(index);
                    iter++;
                }
                Console.WriteLine("Random numbers were found in {0} iterations: ", iter);
                foreach (int num in rndIndexes)
                {
                    Console.WriteLine(num);
                }
                Console.ReadKey();
            }
        }
    }
