    namespace Permutation
    {
        using System;
        using System.Collections.Generic;
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Generating list.");
    
                var dice = new List<ThreeDice>();
    
                for (int x = 1; x <= 6; x++)
                {
                    for (int y = 1; y <= 6; y++)
                    {
                        for (int z = 1; z <= 6; z++)
                        {
                            var die = new ThreeDice(x, y, z);
                            
                            if (dice.Contains(die))
                            {
                                Console.WriteLine(die + " already exists.");
                            }
                            else
                            {
                                dice.Add(die);
                            }
                        }
                    }
                }
    
                Console.WriteLine(dice.Count + " permutations generated.");
    
                foreach (var die in dice)
                {
                    Console.WriteLine(die);
                }
    
                Console.ReadKey();
            }
        }
    }
