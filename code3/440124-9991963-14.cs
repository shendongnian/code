    using System;
    namespace ConsoleApplication17
    {
        class Program
        {
            static void Main(string[] args)
            {
                { //without locks
                    var startTime = DateTime.Now;
                    int i2=0;
                    for (int i = 0; i < 6000000; i++)
                    {
                        i2++;
                    }
                    Console.WriteLine(i2);
                    Console.WriteLine(DateTime.Now.Subtract(startTime)); //0.01 seconds on my machine
                }
                { //with locks
                    var startTime = DateTime.Now;
                    var obj = new Object();
                    int i2=0;
                    for (int i = 0; i < 6000000; i++)
                    {
                        lock (obj)
                        {
                            i2++;
                        }
                    }
                    Console.WriteLine(i2);
                    Console.WriteLine(DateTime.Now.Subtract(startTime)); //0.14 seconds on my machine, and this isn't even in parallel.
                }
                Console.ReadLine();
            }
        }
    }
