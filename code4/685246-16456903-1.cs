    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Thing> things = new List<Thing>()
                {
                    new Thing(){ No = 1, Grouper = 'X', Sorter = 3  },
                    new Thing(){ No = 2, Grouper = 'X', Sorter = 2  },
                    new Thing(){ No = 3, Grouper = 'X', Sorter = 1  },
                    new Thing(){ No = 4, Grouper = 'Y', Sorter = 3  },
                    new Thing(){ No = 5, Grouper = 'Y', Sorter = 2  },
                    new Thing(){ No = 6, Grouper = 'Y', Sorter = 5  },
                    new Thing(){ No = 7, Grouper = 'Z', Sorter = 4  }
                };
    
                var test = from thing in things
                           group thing by thing.Grouper into thingGroup
                           select thingGroup.OrderBy(tg => tg.Sorter).First();
    
                foreach (var thing in test)
                {
                    Console.WriteLine(thing);
                }
    
                Console.ReadKey();
            }
        }
        class Thing
        {
            public int No { get; set; }
            public char Grouper { get; set; }
            public int Sorter { get; set; }
    
            public override string ToString()
            {
                return string.Format("No: {0}, Grouper: {1}, Sorter: {2}",
                                     No, Grouper, Sorter);
            }
        }
    }
