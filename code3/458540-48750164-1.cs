    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main() {
    
                List<string> thelist = new List<string>();
    
                Thread producer = new Thread(() => {
                    while (true) {
                        thelist.Add("a" + DateTime.Now);
                    }
                });
    
                Thread transformer = new Thread(() => {
                    while (true) {
                        string[] thearray = thelist.ToList().ToArray();
                        Console.WriteLine(thearray.Length);
                    }
                });
                producer.Start();
                transformer.Start();
                Console.ReadKey(true);
            }
        }
    }
